using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDoMoveTransform), true), CanEditMultipleObjects]
public class AcDoMoveTransformEditor : TriggerActionEditor {
    SerializedProperty transformMono;
    SerializedProperty endPos;
    SerializedProperty duration;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUIUtility.labelWidth = 75;
        float saveWidth = position.width;
        EditorGUI.PropertyField(position, transformMono, new GUIContent("Transform"));
        position.y += 18;
        position.width = 150;
        EditorGUI.PropertyField(position, endPos, new GUIContent("EndPos"));
        position.x += 160;
        position.width = saveWidth - 160;
        duration.floatValue = EditorGUI.FloatField(position, new GUIContent("Duration"), duration.floatValue);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        transformMono = serializedObject.FindProperty("transformMono");
        endPos = serializedObject.FindProperty("endPos");
        duration = serializedObject.FindProperty("duration");
    }
}
