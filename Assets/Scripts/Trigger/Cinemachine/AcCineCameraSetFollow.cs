using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Cinemachine;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Cine Camera SetFollow", menuName = "Trigger/Cinemachine/Cine Camera SetFollow", order = 1)]
    public class AcCineCameraSetFollow : TriggerAction {
        [SerializeField] CinemachineVirtualCamera camera = null;
        [SerializeField] Transform follower;
        public override bool Action() {
            if (camera != null && follower != null)
                camera.Follow = follower;
            else {
                Debug.LogWarning("카메라가 없거나 따라갈 객체가 없습니다");
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcCineCameraSetFollow cineCameraSetFollow = CreateInstance<AcCineCameraSetFollow>();
            cineCameraSetFollow.camera = camera;
            cineCameraSetFollow.follower = follower;
            return cineCameraSetFollow;
        }
    }
}