using UnityEditor;
using UnityEngine;
using Cinemachine;
using System.Collections;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Cine SetLens", menuName = "Trigger/Cinemachine/Cine SetLens", order = 1)]
    public class AcCineSetLens : TriggerAction {
        [SerializeField] CinemachineVirtualCamera CVC;
        [SerializeField] bool isOrthographicSize = true;
        [SerializeField] float orthographicSize = 10;

        [SerializeField] bool isNearClipPlane = true;
        [SerializeField] float nearClipPlane = 0.1f;

        [SerializeField] bool isFarClipPlane = true;
        [SerializeField] float farClipPlane = 5000;

        [SerializeField] bool isDutch = true;
        [SerializeField] float dutch = 0;

        [SerializeField] float duration;
        public override bool Action() {
            if (CVC) {
                CVC.StartCoroutine(C_Size(duration));
            }
            else {
                Debug.LogWarning("렌즈설정을 할 카메라가 없습니다.");
            }
            return true;
        }
         IEnumerator C_Size(float duration) {
            float lastTIme = duration;
            float defaultOrthographicSize = CVC.m_Lens.OrthographicSize;
            float defaultNearClipPlane = CVC.m_Lens.NearClipPlane;
            float defaultFarClipPlane = CVC.m_Lens.FarClipPlane;
            float defaultDutch = CVC.m_Lens.Dutch;
            float value;
            while (lastTIme >= 0) {
                lastTIme -= Time.deltaTime;
                value = (duration - lastTIme) / duration;

                if (isOrthographicSize) {
                    CVC.m_Lens.OrthographicSize = Mathf.Lerp(defaultOrthographicSize, orthographicSize, value);
                }
                if (isNearClipPlane) {
                    CVC.m_Lens.NearClipPlane = Mathf.Lerp(defaultNearClipPlane, nearClipPlane, value);
                }
                if (isFarClipPlane) {
                    CVC.m_Lens.FarClipPlane = Mathf.Lerp(defaultFarClipPlane, farClipPlane, value);
                }
                if (isDutch) {
                    CVC.m_Lens.Dutch = Mathf.Lerp(defaultDutch, dutch, value);
                }
                yield return null;
            }
            CVC.m_Lens.OrthographicSize = orthographicSize;
        }
        public override TriggerAction GetCopyTrigger() {
            AcCineSetLens cineSetLens = CreateInstance<AcCineSetLens>();
            cineSetLens.CVC = CVC;
            cineSetLens.isOrthographicSize = isOrthographicSize;
            cineSetLens.isNearClipPlane = isNearClipPlane;
            cineSetLens.isFarClipPlane = isFarClipPlane;
            cineSetLens.isDutch = isDutch;

            cineSetLens.orthographicSize = orthographicSize;
            cineSetLens.nearClipPlane = nearClipPlane;
            cineSetLens.farClipPlane = farClipPlane;
            cineSetLens.dutch = dutch;

            cineSetLens.duration = duration;
            return cineSetLens;
        }
    }
}
