using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcCineSetSoftZone), true), CanEditMultipleObjects]
public class AcCineSetSoftZoneEditor : TriggerActionEditor {
    SerializedProperty CVC;
    SerializedProperty unlimited;
    SerializedProperty width;
    SerializedProperty height;
    SerializedProperty biasX;
    SerializedProperty biasY;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        EditorGUIUtility.labelWidth = 60;
        position.x += 150;
        unlimited.boolValue = EditorGUI.Toggle(position, "Unlimited", unlimited.boolValue);
        position.y += 18;
        position.x -= 150;
        EditorGUI.PropertyField(position, CVC, new GUIContent("Ä«¸Þ¶ó"));
        if (!unlimited.boolValue) {
            EditorGUIUtility.fieldWidth = 30;
            position.y += 18;
            float saveWidth1 = position.width;
            position.width = saveWidth1 * 0.5f;
            width.floatValue = EditorGUI.Slider(position, "Width", width.floatValue, 0, 2);

            position.y += 18;
            biasX.floatValue = EditorGUI.Slider(position, "BiasX", biasX.floatValue, -0.5f, 0.5f);
            position.y -= 18;

            position.x += saveWidth1 * 0.5f;
            height.floatValue = EditorGUI.Slider(position, "Height", height.floatValue, 0, 2);

            position.y += 18;
            biasY.floatValue = EditorGUI.Slider(position, "BiasY", biasY.floatValue, -0.5f, 0.5f);
        }
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        CVC = serializedObject.FindProperty("CVC");
        unlimited = serializedObject.FindProperty("unlimited");
        width = serializedObject.FindProperty("width");
        height = serializedObject.FindProperty("height");
        biasX = serializedObject.FindProperty("biasX");
        biasY = serializedObject.FindProperty("biasY");
    }
}
