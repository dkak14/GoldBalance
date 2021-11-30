using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Weapon
{
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 attackSize;
    bool attack;
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
                Collider2D[] hits = Physics2D.OverlapBoxAll((Vector2)unitController.transform.position + offset, attackSize, 0, 1 << LayerMask.NameToLayer("Enemy"));
                for (int i = 0; i < hits.Length; i++) {
                    UnitControllerBase unit;
                    if (hits[i].TryGetComponent(out unit)) {
                        unit.Damaged(weaponData.damage);
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
    }
    private void OnDrawGizmos() {
        if (unitController) {
            Vector2 attackOffset = spriteRenderer.flipY ? new Vector2(-offset.x, offset.y) : offset;
            Gizmos.DrawWireCube((Vector2)unitController.transform.position + attackOffset, attackSize);
        }
    }
}
