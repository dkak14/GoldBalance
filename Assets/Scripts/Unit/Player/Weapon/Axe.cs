using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : Weapon
{
    Coroutine attackDelayRoutine;
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 attackSize;

    bool attack = false;
    public override void NotSelectPickUp(PlayerPickUpController pickUpController) {
        base.NotSelectPickUp(pickUpController);
        AttackDelayEnd();
    }
    public override void Throw() {
        AttackDelayEnd();
        base.Throw();
    }
    protected override void Aim(Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        if (spriteData == null)
            return;

        dst += dst * (culTimeValue);
        base.Aim(centerOffset, dir, dst, spriteData);
        if (unitController.FlipX) {
            float angle = (Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg;
            spriteRenderer.flipY = true;
            transform.rotation = Quaternion.Euler(0, 0, 180 - spriteData.weaponAngle);
        }
        else {
            float angle = (Mathf.Atan2(dir.y, dir.x)) * Mathf.Rad2Deg;
            angle += +spriteData.weaponAngle - 240 * culTimeValue;
            spriteRenderer.flipY = false;
            transform.rotation = Quaternion.Euler(0, 0, spriteData.weaponAngle);
        }

        if(spriteData.clipName == "PlayerAxe_Attack" && spriteData.index >= 4) {
            if (!attack) {
                attack = true;
                Collider2D[] hits = Physics2D.OverlapBoxAll((Vector2)unitController.transform.position + offset, attackSize, 0, 1 << LayerMask.NameToLayer("Enemy"));
                for (int i = 0; i < hits.Length; i++) {
                    UnitControllerBase unit;
                    if (hits[i].TryGetComponent(out unit)) {
                        unit.Damaged(weaponData.damage);
                    }
                    Debug.Log("РћСп");
                }
            }
        }
        else {
            attack = false;
        }
    }
    protected override void Attack(Vector2 dir) {
        unitAnimator.SetTrigger("Attack");
        if(attackDelayRoutine != null) {
            StopCoroutine(attackDelayRoutine);
            attackDelayRoutine = null;
        }
        attackDelayRoutine = StartCoroutine(C_AttackDelay());
    }
    IEnumerator C_AttackDelay() {
        yield return null;
        AnimationClip clip = unitAnimator.GetCurrentAnimatorClipInfo(0)[0].clip;
        unitMoveController.isMove = false;
        unitMoveController.isJump = false;
        float animLength = clip.length;
        float delayTime = animLength;
        if (animLength > weaponData.attackSpeed) {
            unitAnimator.speed = animLength / weaponData.attackSpeed;
            delayTime = weaponData.attackSpeed;
        }
        yield return new WaitForSeconds(delayTime);
        AttackDelayEnd();
    }
    void AttackDelayEnd() {
        unitMoveController.isMove = true;
        unitMoveController.isJump = true;
        unitAnimator.speed = 1;
        if (attackDelayRoutine != null) {
            StopCoroutine(attackDelayRoutine);
            attackDelayRoutine = null;
        }
    }
    protected override bool AttackCondition() {
        if (unitAnimator.GetBool("isJump")) {
            return false;
        }
        else {
            return true;
        }
    }
    private void OnDrawGizmos() {
        if (unitController) {
            Vector2 attackOffset = spriteRenderer.flipY ? new Vector2(-offset.x, offset.y) : offset;
            Gizmos.DrawWireCube((Vector2)unitController.transform.position + attackOffset, attackSize);
        }
    }
}
