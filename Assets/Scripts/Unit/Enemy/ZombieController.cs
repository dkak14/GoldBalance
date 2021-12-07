using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ZombieController : EnemyController
{
    [SerializeField] Vector2 attackSize;
    [SerializeField] Vector2 offset;
    Vector2 attackOffset { get { return spriteRenderer.flipX ? new Vector2(-offset.x, offset.y) : offset; } }
    protected override void Update() {
        if (!animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Zombie_Attack") && !IsActiveState(UnitAnimState.Die)) {
            if (playerController == null) {
                Collider2D hit = Physics2D.OverlapCircle(transform.position, sensingRange, playerLayerMask);
                if (hit) {
                    animator.SetBool("isMove", true);
                    hit.TryGetComponent(out playerController);
                }
            }
            if (playerController != null) {
                animator.SetBool("isMove", true);
                moveController.Move(playerController.transform);
                RaycastHit2D playerHit = Physics2D.CircleCast(transform.position, attackRange, Vector2.up, attackRange, playerLayerMask);
                if (playerHit) {
                    animator.SetTrigger("Attack");
                }
            }
        }
        if(Mathf.Abs(rigidbody2d.velocity.x) > 0.1f) {
            animator.SetBool("isMove", true);
        }
        else {
            animator.SetBool("isMove", false);
        }
    }

    public override void Attack() {
        Collider2D[] hits = Physics2D.OverlapBoxAll((Vector2)transform.position + attackOffset, attackSize, 0, playerLayerMask);
        for (int i = 0; i < hits.Length; i++) {
            UnitControllerBase unit;
            if (hits[i].TryGetComponent(out unit)) {
                unit.Damaged(damage, this, WeaponType.NULL);
            }
        }
    }
    protected override void OnDrawGizmos() {
        base.OnDrawGizmos();
        Gizmos.color = Color.white;
        if (spriteRenderer) {
            Gizmos.DrawWireCube((Vector2)transform.position + attackOffset, attackSize);
        }
        else {
            TryGetComponent(out spriteRenderer);
        }
    }
}
