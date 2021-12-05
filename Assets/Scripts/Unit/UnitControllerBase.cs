using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public enum UnitAnimState {
    Idle = 1, Cinematic = 2, Die = 3
}
public class UnitControllerBase : MonoBehaviour, IInitialization {
    [SerializeField] int maxHp;
    public int MaxHP { get { return maxHp; } set { maxHp = value; maxHp = Mathf.Max(maxHp, 0); maxHPValueChange(maxHp); } }
    public Action<int> maxHPValueChange = delegate{};
    [SerializeField] int hp;
    public int HP { get { return hp; } set { hp = value; hp = Mathf.Max(hp, 0); hpValueChange(hp); } }
    public Action<int> hpValueChange = delegate { };
    [SerializeField] float speed;
    public float Speed { get { return speed; } set { speed = value; speed = Mathf.Max(speed, 0); speedValueChange(speed); } }
    public Action<float> speedValueChange = delegate { };

    protected SpriteRenderer spriteRenderer;
    protected PlayerInputController playerInputController;
    protected Collider2D collider2d;
    protected Rigidbody2D rigidbody2d;
    [SerializeField, EnumFlags] UnitAnimState state;
    public bool onPlatform;

    public Collider2D onPlatformHitCollider;
    public Action<bool> OnPlatform = delegate { };

    public string unitDataID;
    public int unitFieldID;

    public bool FlipX { get { return spriteRenderer.flipX; } set { spriteRenderer.flipX = value; } }
    public Action DieEvent = delegate { };
    protected virtual void Awake() {
        Initialization();
        EventManager.Instance.SpawnUnit(this);
        EventManager.Instance.SetActiveCutScene += SetActiveCutScene;
    }
    protected virtual void Start() {
    }
    protected virtual void OnDestroy() {
        EventManager.Instance.SetActiveCutScene -= SetActiveCutScene;
    }
    public bool IsActiveState(UnitAnimState flag) {
        if ((state & flag) == flag) {
            return true;
        }
        else {
            return false;
        }
    }
    public void SetActiveState(UnitAnimState flag, bool active) {
        if (active) {
            state |= flag;
        }
        else {
            state &= ~flag;
        }
    }
    IEnumerator C_CheckPlatform() {
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        Vector2 boxSize = new Vector2(collider2d.bounds.size.x * 0.9f, 0.1f);
        int layerMask = 1 << LayerMask.NameToLayer("Platform");
        while (true) {
            Vector2 center = collider2d.bounds.center - Vector3.up * (collider2d.bounds.size.y * 0.5f);
            onPlatformHitCollider = Physics2D.OverlapBox(center, boxSize, 0, layerMask);
            if (onPlatformHitCollider && !Physics2D.GetIgnoreCollision(collider2d, onPlatformHitCollider)) {
                if (!onPlatform)
                    OnPlatform(true);

                onPlatform = true;
            }
            else {
                if (!onPlatform)
                    OnPlatform(false);

                onPlatform = false;
            }
            yield return fixedUpdate;
        }
    }
    public bool Damaged(int damage, UnitControllerBase attacker ,WeaponType type) {
        if (!IsActiveState(UnitAnimState.Cinematic)) {
            damaged(damage,attacker, type);
            if (hp <= 0) {
                DieEvent();
                Die();
                return true;
            }
        }
        return false;
    }
    protected virtual void damaged(int damage, UnitControllerBase attacker, WeaponType type) {
        HP -= damage;
    }
    public void AddForce(Vector2 dir) {
        rigidbody2d.AddForce(dir, ForceMode2D.Impulse);
    }
    public virtual void Die() {
        EventManager.Instance.DieUnit(this, unitFieldID);
        SetActiveState(UnitAnimState.Die, true);
        die();
    }
    protected virtual void die() {
        Destroy(gameObject);
    }
    public virtual void Initialization() {
        TryGetComponent(out rigidbody2d);
        TryGetComponent(out spriteRenderer);
        TryGetComponent(out collider2d);
        TryGetComponent(out playerInputController);
        if (collider2d != null)
            StartCoroutine(C_CheckPlatform());
        hp = maxHp;
    }
    void SetActiveCutScene(bool isActive) {
        if (isActive) {
            SetActiveState(UnitAnimState.Cinematic, true);
        }
        else{
            SetActiveState(UnitAnimState.Cinematic, false);
        }
    }
    void OnDrawGizmos() {
        if (collider2d != null) {
            Vector2 boxSize = new Vector2(collider2d.bounds.size.x * 0.9f, 0.1f);
            Vector2 center = collider2d.bounds.center - Vector3.up * (collider2d.bounds.size.y * 0.5f);
            Gizmos.color = onPlatform ? Color.green : Color.red;

            Gizmos.DrawWireCube(center, boxSize);
        }
    }
}
