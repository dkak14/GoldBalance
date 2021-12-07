using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcAddforce), true), CanEditMultipleObjects]
public class AcAddforceEditor : TriggerActionEditor {
    SerializedProperty rigid;
    SerializedProperty AddVec;
    SerializedProperty forceMode;

    SerializedProperty transform;
    SerializedProperty power;
    SerializedProperty selected;

    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        Rect startRect = position;
        position.y += 18;
        EditorGUIUtility.labelWidth = 68;
        float saaveWidth = position.width;
        position.width = 150;
        EditorGUI.PropertyField(position, rigid, new GUIContent("Rigidbody"));
        position.x += 150;
        position.width = saaveWidth - 150;
        EditorGUI.PropertyField(position, forceMode, new GUIContent("ForceMode"));
        position.width += 150;
        position.x -= 150;
        position.y += 18;

        if (selected.intValue == 0) {
            AddVec.vector3Value = EditorGUI.Vector3Field(position, "Addforce", AddVec.vector3Value);
        }
        else {
            EditorGUI.PropertyField(position, transform, new GUIContent("Target"));
            position.y += 18;
            EditorGUI.PropertyField(position, power, new GUIContent("Power"));
        }
        startRect.y += 82;
        using (new EditorGUILayout.HorizontalScope()) {
            selected.intValue = GUI.Toolbar(startRect, selected.intValue, new string[] { "Center", "Target" });
        }
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        rigid = serializedObject.FindProperty("rigid");
        AddVec = serializedObject.FindProperty("AddVec");
        forceMode = serializedObject.FindProperty("forceMode");

        transform = serializedObject.FindProperty("transform");
        power = serializedObject.FindProperty("power");
        selected = serializedObject.FindProperty("selected");
    }
}
