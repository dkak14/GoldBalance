using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemyController : UnitControllerBase
{
    [SerializeField] protected float sensingRange;
    [SerializeField] protected float attackRange;
    [SerializeField] public int damage;
    protected int playerLayerMask;
    protected PlayerController playerController;
    protected Animator animator;
    protected UnitMoveControllerBase moveController;
    protected virtual void Update() {
       // if (playerController == null) {
       //     Collider2D hit = Physics2D.OverlapCircle(transform.position, sensingRange, playerLayerMask);
       //     if (hit) {
       //         Debug.Log("플레이어");
       //         hit.TryGetComponent(out playerController);
       //     }
       // }
       //if(playerController != null) {
       //     moveController.Move(playerController.transform);
       //     RaycastHit2D playerHit = Physics2D.CircleCast(transform.position, attackRange, Vector2.up, attackRange, playerLayerMask);
       //     if (playerHit) {
       //     }
       // }
    }
    public virtual void Attack() {

    }
    protected override void damaged(int damage, UnitControllerBase attacker, WeaponType type) {
        if (playerController == null) {
            attacker.TryGetComponent(out playerController);
        }
        spriteRenderer.DOKill();
        spriteRenderer.color = new Color(1, 0.2f, 0.2f,1);
        spriteRenderer.DOColor(Color.white, 0.5f);
        base.damaged(damage, attacker, type);
    }

    public override void Initialization() {
        base.Initialization();
        TryGetComponent(out moveController);
        TryGetComponent(out animator);
        playerLayerMask = 1 << LayerMask.NameToLayer("Player");
    }
    protected virtual void OnDrawGizmos() {
        Gizmos.color = playerController ? Color.green : Color.red;
        MyGizmos.DrawWireCicle(transform.position, sensingRange, 30);
        Gizmos.color = Color.red;
        MyGizmos.DrawWireCicle(transform.position, attackRange, 30);
    }
}
