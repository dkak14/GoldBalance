using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "TimeScale", menuName = "Trigger/TimeScale", order = 1)]
    public class AcTimeScale : TriggerAction {
        [SerializeField] float timeScale = 1;
        [SerializeField] float duration;
        //public override void DrawProperty(Rect position) {
        //    SerializedObject So = new SerializedObject(this);
        //    position.y += 18;
        //    EditorGUI.PropertyField(position, So.FindProperty("timeScale"), new GUIContent("TimeScale"));
        //    position.y += 18;
        //    EditorGUI.PropertyField(position, So.FindProperty("duration"), new GUIContent("Duration"));
        //    So.ApplyModifiedProperties();
        //}
        public override bool Action() {
            
            return true;
        }
        IEnumerator C_SetTimeScale() {
            float lastTIme = duration;
            float startScale = Time.timeScale;
            float value;
            while(lastTIme > 0) {
                yield return null;
                lastTIme -= Time.deltaTime;
                value = (duration - lastTIme) / duration;
                Time.timeScale = Mathf.Lerp(startScale, timeScale, value);
            }
            Time.timeScale = timeScale;
        }
        public override TriggerAction GetCopyTrigger() {
            AcTimeScale copy = CreateInstance<AcTimeScale>();
            copy.timeScale = timeScale;
            copy.duration = duration;
            return copy;
        }
    }
}
