using System.Collections;
using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "DoMove Transform", menuName = "Trigger/DoMove Transform", order = 1)]
    public class AcDoMoveTransform : TriggerAction {
        [SerializeField] MonoBehaviour transformMono = null;
        [SerializeField] Transform endPos;
        [SerializeField] float duration;

        public override bool Action() {
            if (transformMono != null) {
                transformMono.StartCoroutine(C_Move());
            }
            return true;
        }
        IEnumerator C_Move() {
            float lastTime = 0;
            Vector2 pos = transformMono.transform.position;
            while (lastTime < duration) {
                transformMono.transform.position = Vector2.Lerp(pos, endPos.position, lastTime / duration);

                lastTime += Time.deltaTime;
                yield return null;
            }
        }
        public override TriggerAction GetCopyTrigger() {
            AcDoMoveTransform doMoveTransform = CreateInstance<AcDoMoveTransform>();
            doMoveTransform.transformMono = transformMono;
            doMoveTransform.endPos = endPos;
            doMoveTransform.duration = duration;
            return doMoveTransform;
        }
    }
}
