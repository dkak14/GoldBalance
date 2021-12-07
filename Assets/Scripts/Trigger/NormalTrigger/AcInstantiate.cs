using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Instantiate", menuName = "Trigger/Instantiate", order = 1)]
    public class AcInstantiate : TriggerAction {
        [SerializeField] GameObject gameObject;
        [SerializeField] bool setParent;
        [SerializeField] Transform parent;
        [SerializeField] Vector3 spawnPos;
        [SerializeField] Vector3 angle;
        [SerializeField] Vector3 scale;

        public override bool Action() {
            if (gameObject != null) {
                GameObject spawnObject = Instantiate(gameObject, spawnPos, Quaternion.Euler(angle.x, angle.y, angle.z));
                if (setParent) {
                    spawnObject.transform.parent = parent;
                }
            }
            else {
                Debug.LogWarning("삭제할 오브젝트가 없습니다");
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcInstantiate instantiate = CreateInstance<AcInstantiate>();
            instantiate.gameObject = gameObject;
            instantiate.setParent = setParent;
            instantiate.spawnPos = spawnPos;
            instantiate.parent = parent;
            instantiate.angle = angle;
            return instantiate;
        }
    }
}
