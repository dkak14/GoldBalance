using UnityEngine;
using System;


[Serializable]
public class TriggerProperty {
    public int LineNum;
    public string PropertyName;
    public Rect Position;
    public TriggerProperty(int lineNum, string propertyName, Rect position) {
        LineNum = lineNum;
        PropertyName = propertyName;
        Position = position;
    }
}