using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcSetActive), true),CanEditMultipleObjects]
public class AcSetActiveEditor : TriggerActionEditor
{
    SerializedProperty Active;
    SerializedProperty gameObject;

    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        position.height = 18;
        EditorGUI.PropertyField(position, gameObject);
        position.y += 18;
        EditorGUIUtility.labelWidth = 40;
        Active.boolValue = EditorGUI.Toggle(position, new GUIContent("Active"), Active.boolValue);
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        Active = serializedObject.FindProperty("Active");
        gameObject = serializedObject.FindProperty("gameObject");
    }
}
