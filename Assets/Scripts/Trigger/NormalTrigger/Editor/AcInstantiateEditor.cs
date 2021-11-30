using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcInstantiate), true), CanEditMultipleObjects]
public class AcInstantiateEditor : TriggerActionEditor { 
    SerializedProperty gameObject;
    SerializedProperty setParent;
    SerializedProperty parent;
    SerializedProperty spawnPos;
    SerializedProperty angle;
    SerializedProperty scale;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.x += 150;
        setParent.boolValue = EditorGUI.Toggle(position, "IsSetParent", setParent.boolValue);
        position.y += 18;
        position.x -= 150;
        EditorGUI.PropertyField(position, gameObject, new GUIContent("Game Object"));

        if (setParent.boolValue) {
            position.y += 18;
            EditorGUI.PropertyField(position, parent, new GUIContent("Parent"));
        }
        position.y += 18;
        EditorGUI.LabelField(position, "SpawnPos");
        position.width -= 100;
        position.x += 100;
        EditorGUI.PropertyField(position, spawnPos, new GUIContent(""));
        position.y += 18;
        position.x -= 100;
        EditorGUI.LabelField(position, "Angle");
        position.x += 100;
        EditorGUI.PropertyField(position, angle, new GUIContent(""));
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        gameObject = serializedObject.FindProperty("gameObject");
        setParent = serializedObject.FindProperty("setParent");
        parent = serializedObject.FindProperty("parent");
        spawnPos = serializedObject.FindProperty("spawnPos");
        angle = serializedObject.FindProperty("angle");
        scale = serializedObject.FindProperty("scale");
    }
}
