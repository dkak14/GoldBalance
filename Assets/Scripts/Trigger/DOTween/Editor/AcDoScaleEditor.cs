using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDoScale), true), CanEditMultipleObjects]
public class AcDoScaleEditor : TriggerActionEditor {
    SerializedProperty transform;
    SerializedProperty scale;
    SerializedProperty duration;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, transform, new GUIContent("Transform"));
        position.y += 18;
        EditorGUI.PropertyField(position, duration, new GUIContent("Duration"));
        position.y += 18;
        EditorGUI.PropertyField(position, scale, new GUIContent("Scale"));
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        transform = serializedObject.FindProperty("transform");
        scale = serializedObject.FindProperty("scale");
        duration = serializedObject.FindProperty("duration");
    }
}
