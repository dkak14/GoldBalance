using System;
using System.Collections;
using UnityEngine;
namespace Triggers {
    [CreateAssetMenu(fileName = "DebugUnitMove", menuName = "Trigger/Gold/DebugUnitMove", order = 1)]
    public class AcDebugUnitMove : TriggerAction {
        [SerializeField] UnitMoveControllerBase moveController;
        [SerializeField] float axis;
        [SerializeField] float speed;
        [SerializeField] float duration = 0;
        public override bool Action() {
            moveController.StartCoroutine(C_Move(duration));
            return true;
        }
        IEnumerator C_Move(float duration) {
            float lastTime = duration;
            WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
            while(lastTime > 0) {
                lastTime -= Time.fixedDeltaTime;
                moveController.DebugMove(axis, speed, speed);
                yield return fixedUpdate;
            }
        }
        public override TriggerAction GetCopyTrigger() {
            AcDebugUnitMove copy = CreateInstance<AcDebugUnitMove>();
            copy.moveController = moveController;
            copy.axis = axis;
            copy.speed = speed;
            copy.duration = duration;
            return copy;
        }
    }
}
