using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDestroy), true), CanEditMultipleObjects]
public class AcDestroyEditor : TriggerActionEditor {
    SerializedProperty gameObject;
    SerializedProperty timer;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, gameObject, new GUIContent("Game Object"));
        position.y += 18;
        EditorGUI.PropertyField(position, timer, new GUIContent("Timer"));
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        gameObject = serializedObject.FindProperty("gameObject");
        timer = serializedObject.FindProperty("timer");
    }
}
