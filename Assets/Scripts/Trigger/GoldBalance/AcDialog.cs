using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Dialog", menuName = "Trigger/Gold/Dialog", order = 1)]
    public class AcDialog : TriggerAction {
        public SODialogData soDialogData;
        [SerializeField] Dialog dialog;
        
        public override bool Action() {
            TalkManager.Instance.StartTalk(dialog);
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcDialog copy = CreateInstance<AcDialog>();
            copy.soDialogData = soDialogData;
            copy.dialog = dialog;
            return copy;
        }
    }
}
