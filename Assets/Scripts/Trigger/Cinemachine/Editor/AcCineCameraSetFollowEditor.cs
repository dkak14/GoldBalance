using UnityEngine;
using UnityEditor;
using Triggers;
[CustomEditor(typeof(AcCineCameraSetFollow), true), CanEditMultipleObjects]
public class AcCineCameraSetFollowEditor : TriggerActionEditor {
    SerializedProperty camera;
    SerializedProperty follower;
    public override void DrawGUI(SerializedObject serializedObject, Rect position) {
        position.y += 18;
        EditorGUI.PropertyField(position, camera, new GUIContent("Camera"));
        position.y += 18;
        EditorGUI.PropertyField(position, follower, new GUIContent("follower"));
    }

    public override void OnTriggerEnable(SerializedObject serializedObject) {
        camera = serializedObject.FindProperty("camera");
        follower = serializedObject.FindProperty("follower");
    }
}
