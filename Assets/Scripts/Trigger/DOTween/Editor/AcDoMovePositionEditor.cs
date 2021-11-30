using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDoMovePosition), true), CanEditMultipleObjects]
public class AcDoMovePositionEditor : TriggerActionEditor {
    SerializedProperty moveTransform;
    SerializedProperty endPos;
    SerializedProperty duration;
    SerializedProperty ease;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUIUtility.labelWidth = 75;
        float saveWidth = position.width;
        EditorGUI.PropertyField(position, moveTransform, new GUIContent("Transform"));
        position.y += 18;
        position.width = 150;
        EditorGUI.PropertyField(position, endPos, new GUIContent("EndPos"));
        position.x += 160;
        position.width = saveWidth - 160;
        duration.floatValue = EditorGUI.FloatField(position, new GUIContent("Duration"), duration.floatValue);
        position.y += 18;
        EditorGUI.PropertyField(position, ease, new GUIContent("Ease"));
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        moveTransform = serializedObject.FindProperty("moveTransform");
        endPos = serializedObject.FindProperty("endPos");
        duration = serializedObject.FindProperty("duration");
        ease = serializedObject.FindProperty("ease");
    }
}
