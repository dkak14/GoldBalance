using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using GameSave;
public class PlayerPickUpController : MonoBehaviour, IInitialization
{
    PlayerInputController playerInputController;
    PlayerAnimController animController;
    PlayerController playerController;
    Animator animator;
    [SerializeField] float pickUpRange;
    [SerializeField] PlayerWeapon playerWeapon;

    [SerializeField] float handDst;
    [SerializeField] Vector2 handOffset;
    Vector2 mouseDir;
    protected SpriteRenderer spriteRenderer;
    Camera mainCamera;

    int puoLayerMask;

    RaycastHit2D closePUO;
    void Awake()
    {
        Initialization();
        EventManager.Instance.SceneChangeStart += SceneChangeStart;
        EventManager.Instance.SceneChangeEnd += SceneChangeEnd;
    }
    void Start() {
        animController.AnimType = WeaponType.NULL;
    }
    void OnDestroy() {
        EventManager.Instance.SceneChangeStart -= SceneChangeStart;
        EventManager.Instance.SceneChangeEnd -= SceneChangeEnd;
        playerController.DieEvent -= PlayerDie;
    }
    void Update() {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 handCenter = (Vector2)transform.position + handOffset;
        mouseDir = (mousePosition - (Vector2)transform.position).normalized;

        if(playerWeapon.selectWeapon != null) {

            PlayerAnimClipSpriteData clipData = animController.GetCurrentClipData();
            if (clipData != null) {
                Vector2 dir;
                Vector2 offSet;
                if (!spriteRenderer.flipX) {
                    float weaponAngle = clipData.weaponAngle * Mathf.Deg2Rad;
                    dir = new Vector2(Mathf.Cos(weaponAngle), Mathf.Cos(weaponAngle));
                    offSet = clipData.weaponOffset;
                }
                else {
                    float weaponAngle = (180 - clipData.weaponAngle) * Mathf.Deg2Rad;
                    dir = new Vector2(Mathf.Cos(weaponAngle), Mathf.Cos(weaponAngle));
                    offSet = new Vector2(-clipData.weaponOffset.x, clipData.weaponOffset.y);
                }
                playerWeapon.selectWeapon.spriteRenderer.sortingOrder = clipData.orderInLayer;
                playerWeapon.selectWeapon.AimUpdate(offSet, dir, 0, clipData);
            }
        }
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, pickUpRange, Vector2.up, pickUpRange, puoLayerMask);
        if(hits.Length > 0) {
            float minDst = pickUpRange * 10;
            for(int i = 0; i< hits.Length; i++) {
                float dst = Vector2.Distance(transform.position, hits[i].transform.position);
                if(dst < minDst) {
                    minDst = dst;
                    closePUO = hits[i];
                }
            }
        }
        else {
            closePUO = new RaycastHit2D();
        }
    }
    void OnDisable() {
        playerInputController.GetInputAction("LeftClick").inputAction.started -= PickUpObjectAction;
    }
    void SceneChangeStart(string sceneName) {
        SaveData weaponData = new SaveData();
        for(int i = 0; i < playerWeapon.WeaponCount; i++) {
            PickUpObject puo = playerWeapon.GetWeapon(i);
            SaveData data;
            if (puo != null) {
                 data = new SaveData(((Weapon)puo).weaponData.ID);
            }
            else {
                data = new SaveData(0);
            }
            Debug.Log("세이브 무기 " + data.GetInt());
            weaponData.AddData(i.ToString(), data);
        }
        weaponData.AddData("SelectIndex",new SaveData(playerWeapon.SelectIndex));
        SaveSystem.SaveSerailizeData("Stage", sceneName +"_Weapon", weaponData);
    }
    void SceneChangeEnd() {
        string stageSceneName = SceneManager.GetActiveScene().name;

        SaveData loadData = SaveSystem.LoadDeSerailizedData("Stage", stageSceneName+"_Weapon");
        for (int i = 0; i < playerWeapon.WeaponCount; i++) {
            SaveData data = loadData.GetData(i.ToString());
            Debug.Log("로드 무기 " + data.GetInt());
            Weapon weaponData = WeaponManager.Instance.GetWeapon(data.GetInt());
            if (weaponData != null) {
                Weapon weaponObject = Instantiate(weaponData);
                playerWeapon.SetWeapon(i, weaponObject);
            }
        }
        int selectIndex = loadData.GetData("SelectIndex").GetInt();
        playerWeapon.SelectWeapon(selectIndex);
    }
    void PickUpObjectAction(InputAction.CallbackContext context) {
        if (playerWeapon.selectWeapon != null && !playerController.IsActiveState(UnitAnimState.Cinematic)) {
            if (playerWeapon.selectWeapon.Action(mouseDir)) {
                //if (!animator.GetBool("isMove") || animator.GetBool("isJump"))
                //    animator.SetTrigger("Attack");
            }
        }
    }
    void GetItem(InputAction.CallbackContext context) {
        if (closePUO) {
            PickUpObject puo;
            if (closePUO.transform.gameObject.TryGetComponent(out puo)) {
                playerWeapon.SetWeapon(playerWeapon.SelectIndex, puo);
            }
        }
    }
    void ThrowItem(InputAction.CallbackContext context) {
        playerWeapon.ThrowWeapon(playerWeapon.SelectIndex);
    }
    void ChangeSelectWeapon(PickUpObject puo) {
        if (puo != null) {
            if (puo is Weapon) {
                Weapon weapon = (Weapon)puo;
                animController.AnimType = weapon.weaponData.type;
            }
            else {
                animController.AnimType = WeaponType.NULL;
            }
        }
        else {
            animController.AnimType = WeaponType.NULL; 
        }
    }
    void PlayerDie() {
        playerWeapon.SetActiveWeapon(false);
    }
    public void Initialization() {
        TryGetComponent(out animator);
        TryGetComponent(out spriteRenderer);
        TryGetComponent(out animController);
        TryGetComponent(out playerInputController);
        TryGetComponent(out playerController);

        mainCamera = Camera.main;
        playerInputController.GetInputAction("LeftClick").inputAction.started += PickUpObjectAction;
        playerInputController.GetInputAction("1").inputAction.started += (context)=> { if(!playerController.IsActiveState(UnitAnimState.Die)) playerWeapon.SelectWeapon(0); };
        playerInputController.GetInputAction("2").inputAction.started += (context) => { if (!playerController.IsActiveState(UnitAnimState.Die)) playerWeapon.SelectWeapon(1); };
        playerInputController.GetInputAction("F").inputAction.started += GetItem;
        playerInputController.GetInputAction("Q").inputAction.started += ThrowItem;
        playerWeapon = new PlayerWeapon(this,animController, 2);
        playerWeapon.changeSelectWeapon += ChangeSelectWeapon;
        puoLayerMask = 1 << LayerMask.NameToLayer("PickUpObject");
        playerController.DieEvent += PlayerDie;
    }
}
[System.Serializable]
public class PlayerWeapon {
    PlayerPickUpController pickUpController;
    PlayerAnimController animController;
    [SerializeField] public PickUpObject selectWeapon;
    [SerializeField] List<PickUpObject> objectList;
    public System.Action<PickUpObject> changeSelectWeapon = delegate{};
    int weaponCount;
    int selectIndex;
    public int SelectIndex => selectIndex;
    public int WeaponCount => weaponCount;
    public PlayerWeapon(PlayerPickUpController pickUpController, PlayerAnimController animController, int weaponCount) {
        this.weaponCount = weaponCount;
        this.pickUpController = pickUpController;
        this.animController = animController;
        objectList = new List<PickUpObject>(weaponCount);
        selectIndex = 0;
        for (int i = 0; i< weaponCount; i++) {
            objectList.Add(null);
        }
        changeSelectWeapon(null);
    }
    public void SetActiveWeapon(bool active) {
        if (active) {
            SelectWeaponUpdate();
        }
        else {
            for (int i = 0; i < objectList.Count; i++) {
                if (selectIndex != i && objectList[i] != null) {
                    objectList[i].NotSelectPickUp(pickUpController);
                }
            }
        }
    }
    public void SelectWeapon(int index) {
        if (selectIndex == index)
            return;

        selectIndex = index;
        changeSelectWeapon(objectList[index]);
        EventManager.Instance.SelectWeapon(index, objectList[index]);
        SelectWeaponUpdate();
    }
    void SelectWeaponUpdate() {
        for (int i = 0; i < objectList.Count; i++) {
            if (selectIndex != i && objectList[i] != null) {
                objectList[i].NotSelectPickUp(pickUpController);
            }
        }

        selectWeapon = objectList[selectIndex];
        if (selectWeapon != null) {
            PlayerAnimClipSpriteData clipData = animController.GetCurrentClipData();
            selectWeapon.PickUp(pickUpController, Vector2.zero, Vector2.zero, 1, clipData);
        }
    }
    public void SetWeapon(int index, PickUpObject getObject) {
        ThrowWeapon(index);
        objectList[index] = getObject;
        changeSelectWeapon(objectList[index]);
        EventManager.Instance.GetWeapon(index, getObject);
        SelectWeaponUpdate();
    }
    public PickUpObject GetWeapon(int index) {
        return objectList[index];
    }
    public void ThrowWeapon(int index) {
        if (objectList[index] != null) {
            PickUpObject throwObject = objectList[index];
            objectList[index].Throw();
            objectList[index] = null;
            changeSelectWeapon(objectList[index]);
            EventManager.Instance.ThrowWeapon(index, throwObject);
        }
    }
}
