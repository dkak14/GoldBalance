using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;
namespace Triggers {
    public class TriggerEventWindow : EditorWindow {
        [SerializeField] static TriggerEventWindow triggerEventWindow;
        [SerializeField] static TriggerEvent triggerEvent;
        [SerializeField] static SerializedObject serializedObject;
        [SerializeField] static SerializedProperty eventProperty;
        [SerializeField] MonoBehaviour mono;

        bool isGUiEvent;
        //public static void Open(TriggerEvent triggerEvent) {
        //    triggerEventWindow = (TriggerEventWindow)EditorWindow.GetWindow(typeof(TriggerEventWindow));
        //    TriggerEventWindow.triggerEvent = triggerEvent;
        //    serializedObject = new SerializedObject(triggerEventWindow);
        //    triggerEventWindow.Show();
        //}

        //private void OnGUI() {
        //    if (!isGUiEvent) {
        //        isGUiEvent = true;
        //        return;
        //    }

        //    //if (Event.current.type != EventType.Repaint && Event.current.type != EventType.Layout) {
        //    if (eventProperty == null) {
        //        eventProperty = serializedObject.FindProperty("mono");
        //        return;
        //    }

        //    EditorGUILayout.PropertyField(eventProperty, new GUIContent("GameObject"));
        //    serializedObject.ApplyModifiedProperties();
        //    if (mono != null) {
        //        FindEvent();
        //    }
        //}

        //void FindEvent() {
        //    Component[] compos = mono.GetComponents<Component>();
        //    foreach (var comp in compos) {
        //        var eventproprty = comp.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

        //        if (eventproprty.Length > 0) {
        //            EditorGUILayout.Space();
        //            EditorGUILayout.LabelField(comp.ToString());
        //        }
        //        for (int i = 0; i < eventproprty.Length; i++) {
        //            if (GUILayout.Button(new GUIContent(eventproprty[i].Name))) {
        //                triggerEvent.gameObject = comp;
        //                Debug.Log(comp);
        //                triggerEvent.componentType = comp.ToString();
        //                triggerEvent.eventName = eventproprty[i].Name;
        //                serializedObject.ApplyModifiedProperties();
        //                triggerEventWindow.Close();
        //            }
        //        }
        //    }
        //}
    }
}