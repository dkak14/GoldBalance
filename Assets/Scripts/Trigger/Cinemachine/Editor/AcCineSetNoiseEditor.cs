using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcCineSetNoise), true), CanEditMultipleObjects]
public class AcCineSetNoiseEditor : TriggerActionEditor
{
    SerializedProperty CVC;
    SerializedProperty noiseSetting;
    SerializedProperty amplitudeGain;
    SerializedProperty frequencyGain;
    SerializedProperty pivotOffset;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, CVC, new GUIContent("Virtual Camera"));
        position.y += 18;
        EditorGUI.PropertyField(position, noiseSetting, new GUIContent("NoiseSetting"));
        position.y += 18;
        amplitudeGain.floatValue = EditorGUI.Slider(position, "AmplitudeGain", amplitudeGain.floatValue, 0, 20);
        position.y += 18;
        frequencyGain.floatValue = EditorGUI.Slider(position, "FrequencyGain", frequencyGain.floatValue, 0, 20);
        position.y += 18;
        EditorGUI.PropertyField(position, pivotOffset, new GUIContent("PivotOffset"));
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        CVC = serializedObject.FindProperty("CVC");
        noiseSetting = serializedObject.FindProperty("noiseSetting");
        amplitudeGain = serializedObject.FindProperty("amplitudeGain");
        frequencyGain = serializedObject.FindProperty("frequencyGain");
        pivotOffset = serializedObject.FindProperty("pivotOffset");
    }
}
