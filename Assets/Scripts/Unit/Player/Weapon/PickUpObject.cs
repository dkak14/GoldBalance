using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour, IInitialization
{
    public SpriteRenderer spriteRenderer;
    protected Rigidbody2D rigidbody2d;
    protected Collider2D collider2d;

    protected PlayerPickUpController pickUpController;
    protected PlayerAnimController unitAnimController;
    protected UnitMoveControllerBase unitMoveController;
    protected UnitControllerBase unitController;
    protected Animator unitAnimator;

    [SerializeField] List<WeaponEffect> effectList;

    PlayerAnimClipSpriteData spriteData;
    Vector2 centerOffset;
    Vector2 dir;
    float dst;
    Coroutine aimRoutine;
    protected virtual void Awake() {
        Initialization();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public virtual void PickUp(PlayerPickUpController pickUpController, Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        this.pickUpController = pickUpController;
        pickUpController.TryGetComponent(out unitController);
        pickUpController.TryGetComponent(out unitAnimController);
        pickUpController.TryGetComponent(out unitMoveController);
        pickUpController.TryGetComponent(out unitAnimator);
        this.centerOffset = centerOffset;
        this.dir = dir;
        this.dst = dst;
        this.spriteData = spriteData;
        gameObject.SetActive(true);
        if (aimRoutine == null)
        aimRoutine = StartCoroutine(C_Anim());

        rigidbody2d.gravityScale = 0;
        rigidbody2d.velocity = Vector2.zero;
        collider2d.enabled = false;
        collider2d.isTrigger = true;
    }
    public virtual void NotSelectPickUp(PlayerPickUpController pickUpController) {
        if (aimRoutine != null) {
            StopCoroutine(aimRoutine);
            aimRoutine = null;
        }
        gameObject.SetActive(false);
        this.pickUpController = pickUpController;
    }
    public virtual void Throw() {
        if (aimRoutine != null) {
            StopCoroutine(aimRoutine);
            aimRoutine = null;
        }
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = pickUpController.transform.position;
        rigidbody2d.velocity = Vector2.zero;
        rigidbody2d.gravityScale = 1;
        collider2d.enabled = true;
        collider2d.isTrigger = false;
        rigidbody2d.AddForce(Vector2.up * 2, ForceMode2D.Impulse);

        unitController = null;
        unitAnimController = null;
        unitMoveController = null;
        unitAnimator = null;
    }
    public void AimUpdate(Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        this.centerOffset = centerOffset;
        this.dir = dir;
        this.dst = dst;
        this.spriteData = spriteData;
    }
    protected virtual void Aim(Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        transform.position = (Vector2)pickUpController.transform.position + centerOffset + dir * dst;
    }
    public virtual bool Action(Vector2 dir) {
        return true;
    }
    public virtual void DisplayUI(EquipWeaponUI ui) { }
    IEnumerator C_Anim() {
        while (pickUpController != null) {
            if (spriteData != null) {
                Aim(centerOffset, dir, dst, spriteData);
                for (int i = 0; i < effectList.Count; i++) {
                    if (effectList[i].clipName == spriteData.clipName && effectList[i].index == spriteData.index) {
                        if (spriteRenderer.flipY) {
                            effectList[i].effectObject.flipY = effectList[i].trueFlipX.flip;
                            effectList[i].effectObject.transform.position = (Vector2)transform.position + effectList[i].trueFlipX.offset;
                            effectList[i].effectObject.transform.rotation = Quaternion.Euler(0, 0, effectList[i].trueFlipX.angle);
                        }
                        else {
                            effectList[i].effectObject.flipY = false;
                            effectList[i].effectObject.transform.position = (Vector2)transform.position+ effectList[i].falseFlipX.offset;
                            effectList[i].effectObject.transform.rotation = Quaternion.Euler(0, 0, effectList[i].falseFlipX.angle);
                        }
                        effectList[i].effectObject.gameObject.SetActive(true);
                    }
                    else {
                        effectList[i].effectObject.gameObject.SetActive(false);
                    }
                }
            }
            yield return null;
        }
    }
    public virtual void Initialization() {
        TryGetComponent(out spriteRenderer);
        TryGetComponent(out rigidbody2d);
        TryGetComponent(out collider2d);
    }
}
