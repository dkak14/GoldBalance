using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcSetAnimatorParam), true), CanEditMultipleObjects]
public class AcSetAnimatorParamEditor : TriggerActionEditor {
    SerializedProperty paramType;
    SerializedProperty animator;
    SerializedProperty paramName;
    SerializedProperty intParam;
    SerializedProperty floatParam;
    SerializedProperty boolParam;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, this.paramType, new GUIContent("paramType"));
        EditorGUIUtility.labelWidth = 60;
        position.y += 18;
        float saveX = position.x;
        float saveWidth = position.width;
        position.width = saveWidth * 0.5f - 10;
        EditorGUI.PropertyField(position, paramName, new GUIContent("Param"));

        position.x += position.width + 20;
        EditorGUI.PropertyField(position, animator, new GUIContent("Animator"));

        position.x = saveX;
        position.width = saveWidth;
        position.y += 18;
        int paramType = this.paramType.enumValueIndex;
        switch (paramType) {
            case (int)AcSetAnimatorParam.AnimatorParamType.Int:
                EditorGUI.PropertyField(position, intParam, new GUIContent("Int"));
                break;
            case (int)AcSetAnimatorParam.AnimatorParamType.Float:
                EditorGUI.PropertyField(position, floatParam, new GUIContent("Float"));
                break;
            case (int)AcSetAnimatorParam.AnimatorParamType.Bool:
                EditorGUI.PropertyField(position, boolParam, new GUIContent("Bool"));
                break;
            case (int)AcSetAnimatorParam.AnimatorParamType.Trigger:
                break;
        }
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        paramType = serializedObject.FindProperty("paramType");
        animator = serializedObject.FindProperty("animator");
        paramName = serializedObject.FindProperty("paramName");
        intParam = serializedObject.FindProperty("intParam");
        floatParam = serializedObject.FindProperty("floatParam");
        boolParam = serializedObject.FindProperty("boolParam");
    }
}
