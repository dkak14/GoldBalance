using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TriggerCollision : MonoBehaviour {
    [SerializeField] LayerMask layerMask;
    [SerializeField] string eventID;
    private void OnTriggerEnter2D(Collider2D collision) {
        int layerFlag = 1 << collision.gameObject.layer;
        if ((layerMask & layerFlag) == layerFlag) {
            EventManager.Instance.TriggerEventMessage(eventID);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision) {
        int layerFlag = 1 << collision.gameObject.layer;
        if ((layerMask & layerFlag) == layerFlag) {
            EventManager.Instance.TriggerEventMessage(eventID);
        }
    }
}
