using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : UnitControllerBase
{
    [SerializeField] float sensingRange;
    [SerializeField] float attackRange;
    int playerLayerMask;
    PlayerController playerController;
    UnitMoveControllerBase moveController;
    public void Update() {
        if (playerController == null) {
            Collider2D hit = Physics2D.OverlapCircle(transform.position, sensingRange, playerLayerMask);
            if (hit) {
                Debug.Log("플레이어");
                hit.TryGetComponent(out playerController);
            }
        }
       if(playerController != null) {
            moveController.Move(playerController.transform);
            RaycastHit2D playerHit = Physics2D.CircleCast(transform.position, attackRange, Vector2.up, attackRange, playerLayerMask);
            if (playerHit) {
            }
        }
    }
    public void Attack() {

    }
    protected override void damaged(int damage) {
        base.damaged(damage);
    }
    public override void Initialization() {
        base.Initialization();
        TryGetComponent(out moveController);
        playerLayerMask = 1 << LayerMask.NameToLayer("Player");
    }
    private void OnDrawGizmos() {
        Gizmos.color = playerController ? Color.green : Color.red;
        MyGizmos.DrawWireCicle(transform.position, sensingRange, 30);
        Gizmos.color = Color.red;
        MyGizmos.DrawWireCicle(transform.position, attackRange, 30);
    }
}
