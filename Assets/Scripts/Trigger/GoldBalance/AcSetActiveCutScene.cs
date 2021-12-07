using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Active CutScene", menuName = "Trigger/Gold/Active CutScene", order = 1)]
    public class AcSetActiveCutScene : TriggerAction {
        [SerializeField] bool isActive;
        public override bool Action() {
            EventManager.Instance.SetActiveCutScene(isActive);
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcSetActiveCutScene copy = CreateInstance<AcSetActiveCutScene>();
            copy.isActive = isActive;
            return copy;
        }
    }
}
