using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcAddTransform), true), CanEditMultipleObjects]
public class AcAddTransformEditor : TriggerActionEditor {
    SerializedProperty transform;
    SerializedProperty AddVec;

    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, transform);
        position.y += 18;
        AddVec.vector3Value = EditorGUI.Vector3Field(position, "MovePos", AddVec.vector3Value);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        transform = serializedObject.FindProperty("transform");
        AddVec = serializedObject.FindProperty("AddVec");
    }
}
