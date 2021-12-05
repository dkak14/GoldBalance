using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcCinePriority), true), CanEditMultipleObjects]

public class AcCinePriorityEditor : TriggerActionEditor {
    SerializedProperty CVC;
    SerializedProperty priority;
    SerializedProperty duration;
    GUIContent CVCContent;
    GUIContent priorityContent;
    GUIContent durationContent;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, CVC, CVCContent);
        position.y += 18;
        EditorGUI.PropertyField(position, priority, priorityContent);
        position.y += 18;
        EditorGUI.PropertyField(position, duration, durationContent);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        CVC = serializedObject.FindProperty("CVC");
        priority = serializedObject.FindProperty("priority");
        duration = serializedObject.FindProperty("duration");

        CVCContent = new GUIContent("CVC");
        priorityContent = new GUIContent("Priority");
        durationContent = new GUIContent("Duration");
    }
}
