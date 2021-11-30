using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "DoMove Position", menuName = "Trigger/DOTween/DoMove Position", order = 1)]
    public class AcDoMovePosition : TriggerAction {
        [SerializeField] Transform moveTransform = null;
        [SerializeField] Vector3 endPos;
        [SerializeField] float duration;
        [SerializeField] Ease ease = Ease.Linear;
        public override bool Action() {
            if (moveTransform != null) {
                moveTransform.DOMove(endPos, duration).SetEase(ease);
            }
            else {
                Debug.LogWarning("AcDoMovePosition 을 할 객체가 없습니다.");
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcDoMovePosition doMovePosition = CreateInstance<AcDoMovePosition>();
            doMovePosition.moveTransform = moveTransform;
            doMovePosition.endPos = endPos;
            doMovePosition.duration = duration;
            return doMovePosition;
        }
    }
}
