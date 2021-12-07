using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
namespace Triggers {
    [CreateAssetMenu(fileName = "DebugErrorText", menuName = "Trigger/DebugErrorText", order = 1)]
    public class AcDebugErrorText : TriggerAction {
        [SerializeField] string Text;
        public override bool Action() {
            Debug.LogError(Text);
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcDebugErrorText debugErrorText = CreateInstance<AcDebugErrorText>();
            debugErrorText.Text = Text;
            return debugErrorText;
        }
    }
}