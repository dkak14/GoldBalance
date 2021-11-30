using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcSpawnEffect), true), CanEditMultipleObjects]
public class AcSpawnEffectEditor : TriggerActionEditor {
    SOEffectObject soEffectObject;
    SerializedProperty id;
    SerializedProperty scale;
    SerializedProperty spawnPos;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        float dst = 153;
        position.x += dst;
        position.width -= dst;
        if(GUI.Button(position, new GUIContent("미리보기"))) {
            SOEffectObjectWindow.Open(soEffectObject);
        }
        position.x -= dst;
        position.width += dst;
        position.y += 18;
        EditorGUI.PropertyField(position, id, new GUIContent("ID"));
        position.y += 18;
        EditorGUI.PropertyField(position, scale, new GUIContent("Scale"));
        position.y += 18;
        EditorGUI.PropertyField(position, spawnPos, new GUIContent("SpawnPos"));
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        soEffectObject = ((AcSpawnEffect)target).effectObject;
        id = serializedObject.FindProperty("id");
        scale = serializedObject.FindProperty("scale");
        spawnPos = serializedObject.FindProperty("spawnPos");
    }
}
