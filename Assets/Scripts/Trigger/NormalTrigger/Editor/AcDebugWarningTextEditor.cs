using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(AcDebugWarningText), true), CanEditMultipleObjects]
public class AcDebugWarningTextEditor : TriggerActionEditor
{
    SerializedProperty Text;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        position.height = 18;
        Text.stringValue = EditorGUI.TextField(position, Text.stringValue);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        Text = serializedObject.FindProperty("Text");

    }
}
