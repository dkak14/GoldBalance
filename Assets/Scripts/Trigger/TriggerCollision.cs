using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerCollision : MonoBehaviour {
    [SerializeField] LayerMask layerMask;

    public event System.Action CollisionEvent;
    private void OnTriggerEnter2D(Collider2D collision) {
        int layerFlag = 1 << collision.gameObject.layer;
        if ((layerMask & layerFlag) == layerFlag) {
            if (CollisionEvent != null)
                CollisionEvent();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        int layerFlag = 1 << collision.gameObject.layer;
        if ((layerMask & layerFlag) == layerFlag) {
            if (CollisionEvent != null)
                CollisionEvent();
        }
    }
}
