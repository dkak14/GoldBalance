using UnityEngine;
using UnityEditor;
using System;
namespace Triggers {
    [Serializable, CreateAssetMenu(fileName = "Move Transform", menuName = "Trigger/Move Transform", order = 1)]
    public class AcMoveTransform : TriggerAction {
        [SerializeField] Transform transform = null;
        [SerializeField] Vector3 MovePos = Vector3.zero;
        public override bool Action() {
            if (transform != null)
                transform.position = MovePos;
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcMoveTransform moveTransform = CreateInstance<AcMoveTransform>();
            moveTransform.transform = transform;
            moveTransform.MovePos = MovePos;
            return moveTransform;
        }
    }
}
