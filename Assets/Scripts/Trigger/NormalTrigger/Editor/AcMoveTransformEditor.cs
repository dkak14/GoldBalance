using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcMoveTransform), true), CanEditMultipleObjects]
public class AcMoveTransformEditor : TriggerActionEditor {
    SerializedProperty transform;
    SerializedProperty MovePos;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, transform);
        position.y += 18;
        MovePos.vector3Value = EditorGUI.Vector3Field(position, "MovePos", MovePos.vector3Value);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        transform = serializedObject.FindProperty("transform");
        MovePos = serializedObject.FindProperty("MovePos");
    }
}
