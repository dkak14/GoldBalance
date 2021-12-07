using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionController : MonoBehaviour
{
    PlayerInputController playerInputController;
    PlayerController playerController;
    Collider2D collider2d;
    RaycastHit2D npcHit;
    int npcMask;
    void Start()
    {
        TryGetComponent(out playerInputController);
        TryGetComponent(out playerController);
        TryGetComponent(out collider2d);
        npcMask = 1 << LayerMask.NameToLayer("NPC");

        playerInputController.GetInputAction("F").inputAction.started += Interaction;
    }
    private void OnDestroy() {
        playerInputController.GetInputAction("F").inputAction.started -= Interaction;
    }

    private void FixedUpdate() {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(collider2d.bounds.center, collider2d.bounds.size, 0, Vector2.up,1, npcMask);
        if (hits.Length > 0) {
            float minDst = 100000;
            int minIndex = 0;
            for (int i = 0; i < hits.Length; i++) {
                float dst = Vector2.Distance(transform.position, hits[i].transform.position);
                if(dst < minDst) {
                    minDst = dst;
                    minIndex = i;
                }
            }
            RaycastHit2D hit = hits[minIndex];
            if (npcHit.transform != hit.transform) {
                npcHit = hit;
            }
        }
        else {
            npcHit = new RaycastHit2D();
        }
    }
    void Interaction(UnityEngine.InputSystem.InputAction.CallbackContext context) {
        if (npcHit) {
            NPC npc;
            if(npcHit.transform.TryGetComponent(out npc)) {
                npc.Interaction();
            }
        }
    }
    private void OnDrawGizmos() {
        if (npcHit) {
            MyGizmos.DrawWireCicle(npcHit.transform.position, 1, 30);
        }
    }
}
