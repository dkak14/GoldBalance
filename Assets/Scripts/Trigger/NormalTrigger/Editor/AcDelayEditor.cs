using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcDelay), true), CanEditMultipleObjects]
public class AcDelayEditor : TriggerActionEditor
{
    SerializedProperty DelayTime;
    SerializedProperty time;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        position.height = 18;
        DelayTime.floatValue = EditorGUI.FloatField(position, new GUIContent("Time"), DelayTime.floatValue);
        if (!Application.isPlaying)
            time.floatValue = DelayTime.floatValue;
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        DelayTime = serializedObject.FindProperty("DelayTime");
        time = serializedObject.FindProperty("time");
    }
}
