using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcSetActiveCutScene), true), CanEditMultipleObjects]
public class AcSetActiveCutSceneEditor : TriggerActionEditor {
    SerializedProperty isActive;

    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, isActive);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        isActive = serializedObject.FindProperty("isActive");
    }
}
