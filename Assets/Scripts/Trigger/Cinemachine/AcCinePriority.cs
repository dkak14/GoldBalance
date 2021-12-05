using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Cine Priority", menuName = "Trigger/Cinemachine/Cine Priority", order = 1)]
    public class AcCinePriority : TriggerAction {
        [SerializeField] CinemachineVirtualCamera CVC;
        [SerializeField] int priority;
        [SerializeField] float duration;
        public override bool Action() {
            if (CVC) {
                CVC.StartCoroutine(C_Priority());
            }
            else {
                Debug.LogWarning("Priority를 수정할 가상 카메라가 없습니다.");
            }
            return true;
        }
        IEnumerator C_Priority() {
            int startPriority = CVC.Priority;
            float lastTime = duration;
            while(lastTime > 0) {
                float value = (duration - lastTime) / duration;
                lastTime -= Time.deltaTime;
                CVC.Priority = (int)Mathf.Lerp(startPriority, priority, value);
                yield return null;
            }
            CVC.Priority = priority;
        }
        public override TriggerAction GetCopyTrigger() {
            AcCinePriority copy = CreateInstance<AcCinePriority>();
            copy.CVC = CVC;
            copy.duration = duration;
            return copy;
        }
    }
}
