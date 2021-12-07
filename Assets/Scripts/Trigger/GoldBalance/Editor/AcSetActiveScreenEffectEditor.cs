using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcSetActiveScreenEffect), true), CanEditMultipleObjects]
public class AcSetActiveScreenEffectEditor : TriggerActionEditor {
    SerializedProperty startOrEnd;
    SerializedProperty effectName;
    SerializedProperty duration;
    SerializedProperty value;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        position.height = 18;
        EditorGUIUtility.labelWidth = 75;
        startOrEnd.boolValue = EditorGUI.Toggle(position, new GUIContent("StartOrEnd"), startOrEnd.boolValue);
        position.x += 150;
        position.width -= 150;
        float saveWidth = position.width;
        effectName.stringValue = EditorGUI.TextField(position, new GUIContent("EffectName"), effectName.stringValue);
        position.x -= 150;
        position.y += 18;
        position.width = 125;
        duration.floatValue = EditorGUI.FloatField(position, new GUIContent("Duration"), duration.floatValue);
        position.x += 150;
        position.width = saveWidth;
        EditorGUIUtility.labelWidth = 80;
        value.floatValue = EditorGUI.Slider(position, new GUIContent("Screen Value"), value.floatValue, 0, 1);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        startOrEnd = serializedObject.FindProperty("startOrEnd");
        effectName = serializedObject.FindProperty("effectName");
        duration = serializedObject.FindProperty("duration");
        value = serializedObject.FindProperty("value");
    }
}
