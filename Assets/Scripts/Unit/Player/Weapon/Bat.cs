using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Weapon
{
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 attackSize;
    Vector2 attackOffset { get { return spriteRenderer.flipY ? new Vector2(-offset.x, offset.y) : offset; } }
    bool attack;
    Coroutine attackDelayRoutine;
    protected override void Aim(Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        if (spriteData == null)
            return;

        dst += dst * (culTimeValue);
        base.Aim(centerOffset, dir, dst, spriteData);
        if (unitController.FlipX) {
            spriteRenderer.flipY = true;
            transform.rotation = Quaternion.Euler(0, 0, 180 - spriteData.weaponAngle);
        }
        else {
            spriteRenderer.flipY = false;
            transform.rotation = Quaternion.Euler(0, 0, spriteData.weaponAngle);
        }

        if ((spriteData.clipName == "PlayerBat_Attack"&& spriteData.index == 5) || (spriteData.clipName == "PlayerBat_JumpAttack" && spriteData.index == 4)) {
            if (!attack) {
                attack = true;
                Collider2D[] hits = Physics2D.OverlapBoxAll((Vector2)unitController.transform.position + attackOffset, attackSize, 0, 1 << LayerMask.NameToLayer("Enemy"));
                for (int i = 0; i < hits.Length; i++) {
                    UnitControllerBase unit;
                    if (hits[i].TryGetComponent(out unit)) {
                        int forceDir = unitController.FlipX ? -1 : 1;
                        unit.AddForce(Vector2.right *0.4f* forceDir);
                        Damage(unit);
                    }
                }
            }
        }
        else {
            attack = false;
        }
    }
    protected override bool AttackCondition() {
        return base.AttackCondition();
    }
    protected override void Attack(Vector2 dir) {
        unitAnimator.SetTrigger("Attack");
        if (attackDelayRoutine != null) {
            StopCoroutine(attackDelayRoutine);
            attackDelayRoutine = null;
        }
        attackDelayRoutine = StartCoroutine(C_AttackDelay());
    }
    IEnumerator C_AttackDelay() {
        yield return null;
        AnimationClip clip = unitAnimator.GetCurrentAnimatorClipInfo(0)[0].clip;
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
        unitAnimator.speed = 1;
        if (attackDelayRoutine != null) {
            StopCoroutine(attackDelayRoutine);
            attackDelayRoutine = null;
        }
    }
    private void OnDrawGizmos() {
        if (unitController) {
            Gizmos.DrawWireCube((Vector2)unitController.transform.position + attackOffset, attackSize);
        }
    }
}
