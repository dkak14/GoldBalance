using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpiderController : EnemyController
{
    [SerializeField] SpiderWeb web;
    [SerializeField] float webSpeed;
    [SerializeField] Vector2 offset;
    [SerializeField] float attackCul;
    float cul;
    Vector2 Offset { get { return spriteRenderer.flipX ? new Vector2(-offset.x, offset.y) : offset; } }
    protected override void Update() {
        if (!animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Spider_Attack") && !IsActiveState(UnitAnimState.Die)) {
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
                if (cul <= 0) {
                    if (playerHit) {
                        animator.SetTrigger("Attack");
                    }
                }
            }
            cul -= Time.deltaTime;
        }
        if (Mathf.Abs(rigidbody2d.velocity.x) > 0.1f) {
            animator.SetBool("isMove", true);
        }
        else {
            animator.SetBool("isMove", false);
        }
    }
    protected override void die() {
        transform.gameObject.layer = LayerMask.NameToLayer("DieUnit");
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isDie", true);
        StartCoroutine(C_DieEffect());
    }
    IEnumerator C_DieEffect() {
        yield return new WaitForSeconds(1.5f);
        float waitCycle = 0.05f;
        WaitForSeconds wait = new WaitForSeconds(waitCycle);
        float alpha = 0;
        float lastTime = 1f;
        while (true) {
            spriteRenderer.color = new Color(1, 1, 1, alpha);
            alpha = alpha == 0 ? 1 : 0;
            yield return wait;
            lastTime -= waitCycle;
            if (lastTime <= 0) {
                break;
            }
        }
        transform.DOKill();
        Destroy(gameObject);
    }
    public override void Attack() {
        SpiderWeb webObject= Instantiate(web, (Vector2)transform.position + Offset, Quaternion.identity);
        Vector2 dir = (playerController.transform.position - transform.position).normalized;
        webObject.BulletSetting(this, webSpeed, dir);
        cul = attackCul;
    }
}
