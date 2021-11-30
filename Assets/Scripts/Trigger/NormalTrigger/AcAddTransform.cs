using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Add Transform", menuName = "Trigger/Add Transform", order = 1)]
    public class AcAddTransform : TriggerAction {
        [SerializeField] Transform transform = null;
        [SerializeField] Vector3 AddVec = Vector3.zero;
        public override bool Action() {
            if (transform != null)
                transform.position += AddVec;
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcAddTransform addTransform = CreateInstance<AcAddTransform>();
            addTransform.transform = transform;
            addTransform.AddVec = AddVec;
            return addTransform;
        }
    }
}
