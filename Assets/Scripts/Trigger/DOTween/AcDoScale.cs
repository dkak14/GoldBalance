using UnityEngine;
using UnityEditor;
using DG.Tweening;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "DoScale", menuName = "Trigger/DOTween/DoScale", order = 1)]
    public class AcDoScale : TriggerAction {
        [SerializeField] Transform transform;
        [SerializeField] Vector3 scale;
        [SerializeField] float duration;
        public override bool Action() {
            if (transform != null)
                transform.DOScale(scale, duration);
            else {
                Debug.LogWarning("DoScale을 할 객체가 없습니다.");
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcDoScale doScale = CreateInstance<AcDoScale>();
            doScale.transform = transform;
            doScale.scale = scale;
            doScale.duration = duration;
            return doScale;
        }
    }
}

