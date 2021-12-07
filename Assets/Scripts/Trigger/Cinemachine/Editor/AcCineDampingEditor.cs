using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcCineDamping), true), CanEditMultipleObjects]
public class AcCineDampingEditor : TriggerActionEditor {
    SerializedProperty CVC;
    SerializedProperty x;
    SerializedProperty y;
    SerializedProperty z;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, CVC, new GUIContent("´ýÇÎ Ä«¸Þ¶ó"));
        position.y += 18;
        x.floatValue = EditorGUI.Slider(position, "X", x.floatValue, 0, 20);
        position.y += 18;
        y.floatValue = EditorGUI.Slider(position, "Y", y.floatValue, 0, 20);
        position.y += 18;
        z.floatValue = EditorGUI.Slider(position, "Z", z.floatValue, 0, 20);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        CVC = serializedObject.FindProperty("CVC");
        x = serializedObject.FindProperty("x");
        y = serializedObject.FindProperty("y");
        z = serializedObject.FindProperty("z");
    }
}
