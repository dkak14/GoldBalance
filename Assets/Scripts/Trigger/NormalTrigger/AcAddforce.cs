using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Addforce", menuName = "Trigger/Addforce", order = 1)]
    public class AcAddforce : TriggerAction {
        [SerializeField] Rigidbody2D rigid = null;
        [SerializeField] Vector3 AddVec = Vector3.zero;
        [SerializeField] ForceMode2D forceMode;

        [SerializeField] Transform transform;
        [SerializeField] float power;
        [SerializeField] int selected;
        public override bool Action() {
            if (rigid != null) {
                if (selected == 0) {
                    rigid.AddForce(AddVec, forceMode);
                }
                else {
                    Vector2 dir = (transform.position - rigid.transform.position).normalized;
                    rigid.AddForce(dir * power, forceMode);
                }
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcAddforce addforce = CreateInstance<AcAddforce>();
            addforce.rigid = rigid;
            addforce.AddVec = AddVec;
            addforce.forceMode = forceMode;
            return addforce;
        }
    }
}