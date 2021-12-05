using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcAddTransform), true), CanEditMultipleObjects]

public class AcSoundEditor : TriggerActionEditor {
    SerializedProperty type;
    SerializedProperty soundID;

    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, type);
        position.y += 18;
        EditorGUI.PropertyField(position, soundID);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        type = serializedObject.FindProperty("type");
        soundID = serializedObject.FindProperty("soundID");
    }
}
