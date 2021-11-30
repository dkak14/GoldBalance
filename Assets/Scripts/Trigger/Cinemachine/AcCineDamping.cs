using UnityEngine;
using UnityEditor;
using Cinemachine;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Cine Dumping", menuName = "Trigger/Cinemachine/Cine Dumping", order = 1)]
    public class AcCineDamping : TriggerAction {
        [SerializeField] CinemachineVirtualCamera CVC;
        [SerializeField] float x = 1;
        [SerializeField] float y = 1;
        [SerializeField] float z = 1;
        public override bool Action() {
            if (CVC != null) {
                CinemachineFramingTransposer CFT= CVC.GetCinemachineComponent<CinemachineFramingTransposer>();
                if (CFT != null) {
                    CFT.m_XDamping = x;
                    CFT.m_YDamping = y;
                    CFT.m_ZDamping = z;
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
            AcCineDamping cineDamping = CreateInstance<AcCineDamping>();
            cineDamping.CVC = CVC;
            cineDamping.x = x;
            cineDamping.y = y;
            cineDamping.z = z;
            return cineDamping;
        }
    }
}
