using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDebugUnitMove), true), CanEditMultipleObjects]
public class AcDebugUnitMoveEditor : TriggerActionEditor {
    SerializedProperty moveController;
    SerializedProperty axis;
    SerializedProperty speed;
    SerializedProperty duration;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, moveController);
        position.y += 18;
        EditorGUI.PropertyField(position, axis);
        position.y += 18;
        EditorGUI.PropertyField(position, speed);
        position.y += 18;
        EditorGUI.PropertyField(position, duration);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        moveController = serializedObject.FindProperty("moveController");
        axis = serializedObject.FindProperty("axis");
        speed = serializedObject.FindProperty("speed");
        duration = serializedObject.FindProperty("duration");
    }
}
