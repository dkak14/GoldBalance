using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDebugUnitDie), true), CanEditMultipleObjects]
public class AcDebugUnitDieEditor : TriggerActionEditor {
    SerializedProperty unitController;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, unitController);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        unitController = serializedObject.FindProperty("unitController");
    }
}
