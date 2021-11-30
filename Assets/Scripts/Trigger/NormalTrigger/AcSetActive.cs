using UnityEngine;
using UnityEditor;
using System;
namespace Triggers {
    [Serializable, CreateAssetMenu(fileName = "SetActive", menuName = "Trigger/SetActive", order = 1)]
    public class AcSetActive : TriggerAction {
        [SerializeField] GameObject gameObject = null;
        [SerializeField] bool Active = false;

        public override bool Action() {
            if (gameObject != null)
                gameObject.SetActive(Active);
            else
                Debug.Log("SetActive 할 오브젝트가 없습니다.");
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcSetActive setActive = CreateInstance<AcSetActive>();
            setActive.gameObject = gameObject;
            setActive.Active = Active;
            return setActive;
        }
    }
}