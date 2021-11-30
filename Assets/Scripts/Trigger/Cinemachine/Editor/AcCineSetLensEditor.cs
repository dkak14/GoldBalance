using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcCineSetLens), true), CanEditMultipleObjects]
public class AcCineSetLensEditor : TriggerActionEditor {
    SerializedProperty CVC;
    SerializedProperty isOrthographicSize;
    SerializedProperty orthographicSize;

    SerializedProperty isNearClipPlane;
    SerializedProperty nearClipPlane;

    SerializedProperty isFarClipPlane;
    SerializedProperty farClipPlane;

    SerializedProperty isDutch;
    SerializedProperty dutch;

    SerializedProperty duration;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.x += 100;
        position.width -= 100;
        EditorGUIUtility.labelWidth = 50;
        EditorGUI.PropertyField(position, CVC, new GUIContent("CVC"));
        EditorGUIUtility.labelWidth = 100;
        position.x -= 100;
        position.width += 100;

        position.y += 18;
        isOrthographicSize.boolValue = EditorGUI.Toggle(position, "", isOrthographicSize.boolValue);
        position.x += 30;
        position.width -= 30;
        if (isOrthographicSize.boolValue) {
            EditorGUI.PropertyField(position, orthographicSize, new GUIContent("OrthographicSize"));
        }
        position.x -= 30;

        position.y += 18;
        isNearClipPlane.boolValue = EditorGUI.Toggle(position, "", isNearClipPlane.boolValue);
        position.x += 30;
        if (isNearClipPlane.boolValue) {
            EditorGUI.PropertyField(position, nearClipPlane, new GUIContent("NearClipPlane"));
        }
        position.x -= 30;

        position.y += 18;
        isFarClipPlane.boolValue = EditorGUI.Toggle(position, "", isFarClipPlane.boolValue);
        position.x += 30;
        if (isFarClipPlane.boolValue) {
            EditorGUI.PropertyField(position, farClipPlane, new GUIContent("FarClipPlane"));
        }
        position.x -= 30;

        position.y += 18;
        isDutch.boolValue = EditorGUI.Toggle(position, "", isDutch.boolValue);
        position.x += 30;
        if (isDutch.boolValue) {
            dutch.floatValue = EditorGUI.Slider(position, "Dutch", dutch.floatValue, -180, 180);
        }
        position.x -= 30;
        position.y += 18;

        position.x += 30;
        EditorGUI.PropertyField(position, duration, new GUIContent("Duration"));
    }
    public override void OnTriggerEnable(SerializedObject serializedObject) {
        CVC = serializedObject.FindProperty("CVC");
        isOrthographicSize = serializedObject.FindProperty("isOrthographicSize");
        orthographicSize = serializedObject.FindProperty("orthographicSize");
        isNearClipPlane = serializedObject.FindProperty("isNearClipPlane");
        nearClipPlane = serializedObject.FindProperty("nearClipPlane");
        isFarClipPlane = serializedObject.FindProperty("isFarClipPlane");
        farClipPlane = serializedObject.FindProperty("farClipPlane");
        isDutch = serializedObject.FindProperty("isDutch");
        dutch = serializedObject.FindProperty("dutch");
        duration = serializedObject.FindProperty("duration");
    }
}
