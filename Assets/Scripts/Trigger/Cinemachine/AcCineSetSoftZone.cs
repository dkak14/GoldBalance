using UnityEngine;
using UnityEditor;
using Cinemachine;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Cine Set SoftZone", menuName = "Trigger/Cinemachine/Cine Set SoftZone", order = 1)]
    public class AcCineSetSoftZone : TriggerAction {
        [SerializeField] CinemachineVirtualCamera CVC;
        [SerializeField] bool unlimited = false;
        [SerializeField] float width = 1;
        [SerializeField] float height = 1;
        [SerializeField] float biasX = 0;
        [SerializeField] float biasY = 0;
        public override bool Action() {
            if (CVC != null) {
                CinemachineFramingTransposer CFT = CVC.GetCinemachineComponent<CinemachineFramingTransposer>();
                if (CFT != null) {
                    CFT.m_UnlimitedSoftZone = unlimited;
                    if (!unlimited) {
                        CFT.m_SoftZoneWidth = width;
                        CFT.m_SoftZoneHeight = height;
                        CFT.m_BiasX = biasX;
                        CFT.m_BiasY = biasY;
                    }
                }
                else {
                    Debug.LogWarning("CinemachineFramingTransposer가 없습니다.");
                }
            }
            else {
                Debug.LogWarning("Damping을 수정할 시네머신이 없습니다.");
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcCineSetSoftZone cineSetSoftZone = CreateInstance<AcCineSetSoftZone>();
            cineSetSoftZone.CVC = CVC;
            cineSetSoftZone.unlimited = unlimited;
            cineSetSoftZone.width = width;
            cineSetSoftZone.biasX = biasX;
            cineSetSoftZone.biasY = biasY;
            return cineSetSoftZone;
        }
    }
}
