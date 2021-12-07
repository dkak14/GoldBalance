using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Triggers;
using System;
using UnityEditor;
[CreateAssetMenu(fileName = "DebugWarningText", menuName = "Trigger/DebugWarningText", order = 1)]
public class AcDebugWarningText : TriggerAction
{
    [SerializeField] string Text;
    public override bool Action() {
        Debug.LogWarning(Text);
        return true;
    }
    public override TriggerAction GetCopyTrigger() {
        AcDebugWarningText debugWaringText = CreateInstance<AcDebugWarningText>();
        debugWaringText.Text = Text;
        return debugWaringText;
    }
}
