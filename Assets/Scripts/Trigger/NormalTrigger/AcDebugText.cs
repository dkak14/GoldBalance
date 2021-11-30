using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
namespace Triggers {
    [Serializable, CreateAssetMenu(fileName = "DebugText", menuName = "Trigger/DebugText", order = 1)]
    public class AcDebugText : TriggerAction {
        [SerializeField] string Text;
        public override bool Action() {
            Debug.Log(Text);
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcDebugText debugText = CreateInstance<AcDebugText>();
            debugText.Text = Text;
            return debugText;
        }
    }
}