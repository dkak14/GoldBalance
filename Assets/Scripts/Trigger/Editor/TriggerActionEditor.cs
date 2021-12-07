using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public abstract class TriggerActionEditor : Editor {
    public string TriggerName {
        get { return "test"; }
    }
    public abstract void OnTriggerEnable(SerializedObject serializedObject);
    public abstract void DrawGUI(SerializedObject serializedObject, Rect position);
}