using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class PlayerAnimController : MonoBehaviour
{
    public SpriteRenderer sampleWeapon;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public List<AnimControllerData> animControllerDatas = new List<AnimControllerData>();
    Dictionary<WeaponType, AnimControllerData> animControllerDataDic;

   [SerializeField] WeaponType animType;
    public WeaponType AnimType { get { return animType; } set { animType = value;
            if (animControllerDataDic.ContainsKey(animType)) {
                animator.runtimeAnimatorController = animControllerDataDic[animType].controller;
                Debug.Log(animType + " 애니메이션 체인지");
            }
            else {
                Debug.Log(animType + " 애니메이션 없음");
            }
        }
    }

    void Awake()
    {
        TryGetComponent(out animator);
        TryGetComponent(out spriteRenderer);

        // state = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
        animControllerDataDic = new Dictionary<WeaponType, AnimControllerData>();
        for (int i = 0; i < animControllerDatas.Count; i++) {
            if (!animControllerDataDic.ContainsKey(animControllerDatas[i].type)) {
                animControllerDataDic.Add(animControllerDatas[i].type, animControllerDatas[i]);
            }
            else {
                Debug.LogWarning(animControllerDatas[i].type + "타입의 애니메이션 컨트롤러는 이미 있습니다.");
            }
        }
    }
    //private void Update() {
    //    AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
    //    for (int i = 0; i < clipInfo.Length; i++) {
    //        Debug.Log(animator.GetCurrentAnimatorClipInfo(0)[i].clip.name);
    //    }
    //}
    public PlayerAnimClipSpriteData GetCurrentClipData() {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        if (animControllerDataDic.ContainsKey(animType)) {
            return animControllerDataDic[animType].GetClipDate(clipInfo[0].clip.name, spriteRenderer);
        }
        return null;
    }
    private float GetAnimLength(string animName) {
        float time = 0;
        RuntimeAnimatorController ac = animator.runtimeAnimatorController;

        for (int i = 0; i < ac.animationClips.Length; i++) {
            if (ac.animationClips[i].name == animName) {
                time = ac.animationClips[i].length;
            }
        }
        return time;
    }
    // 어떤 애니메이션 종류의 컨트롤려인지
    [System.Serializable]
    public class AnimControllerData {
        public RuntimeAnimatorController controller;
        public WeaponType type;
        public List<PlayerAnimClipData> animDatas = new List<PlayerAnimClipData>();
        Dictionary<string, PlayerAnimClipData> animClipDataDic;

        public PlayerAnimClipSpriteData GetClipDate(string clipName, SpriteRenderer spriteRenderer) {
            if (animClipDataDic == null) {
                animClipDataDic = new Dictionary<string, PlayerAnimClipData>();
                for (int i = 0; i < animDatas.Count; i++) {
                    if (!animClipDataDic.ContainsKey(animDatas[i].clipName))
                        animClipDataDic.Add(animDatas[i].clipName, animDatas[i]);
                }
            }
            if (animClipDataDic.ContainsKey(clipName)) {
                PlayerAnimClipData animData = animClipDataDic[clipName];
                for (int i = 0; i < animData.clipDatas.Count; i++) {
                    if (spriteRenderer.sprite.name == animData.clipDatas[i].sprite.name) {
                        animData.clipDatas[i].clipName = animData.clipName;
                        animData.clipDatas[i].index = i;
                        return animData.clipDatas[i];
                    }
                }
            }
            return null;
        }
    }
}
[System.Serializable]
public class PlayerAnimClipData {
    public string clipName;
    public List<PlayerAnimClipSpriteData> clipDatas;
    public PlayerAnimClipData(string clipName) {
        this.clipName = clipName;
        clipDatas = new List<PlayerAnimClipSpriteData>();
    }
}
[System.Serializable]
public class PlayerAnimClipSpriteData {
    public Sprite sprite;
    public string clipName;
    public int index;
    public Vector2 weaponOffset;
    public float weaponAngle;
    public int orderInLayer;
}
