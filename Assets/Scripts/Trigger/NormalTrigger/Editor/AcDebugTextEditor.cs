using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDebugText), true), CanEditMultipleObjects]
public class AcDebugTextEditor : TriggerActionEditor
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
