using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(SOEffectObject), true), CanEditMultipleObjects]
public class SOEffectObjectEditor : Editor
{
    SOEffectObject soEffectObject;
    private void OnEnable() {
        soEffectObject = (SOEffectObject)target;
    }
    public override void OnInspectorGUI() {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("previewMaterial"));
        if(EditorGUILayout.DropdownButton(new GUIContent("¼³Á¤ÇÏ±â"), FocusType.Passive)) {
            Debug.Log("ÀÌÆåÆ® Ã¢ ¿ÀÇÂ");
            SOEffectObjectWindow.Open(soEffectObject);
        }
        serializedObject.ApplyModifiedProperties();
    }
}
