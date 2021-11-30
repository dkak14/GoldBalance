using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
namespace Triggers {
    public class TriggerWindow : EditorWindow {
        static TriggerWindow m_TriggerWindow;
        static List<TriggerAction> copyTriggerAction;
        static TriggerController m_TriggerController;
        SerializedObject serializedObject;

        ReorderableList EventReorderable;
        ReorderableList ActionReorderable;
        ReorderableList ConditionReorderable;

        SerializedProperty NumberOfTriggerProperty;
        SerializedProperty EndTypeProperty;
        SerializedProperty EventProperty;
        SerializedProperty ConditionProperty;
        SerializedProperty ActionLogicalOperators;
        SerializedProperty SequenceProperty;

        List<TriggerAction> selectActionList;

        Color SelectColor = new Color(0.403f, 0.6f, 1);

        float labelWidth = 0;
        float fieldWidth = 0;
        float space = 1;

        static bool needInit = false;
        public static void Open(TriggerController triggerGenerator) {
            m_TriggerController = triggerGenerator;
            m_TriggerWindow = (TriggerWindow)EditorWindow.GetWindow(typeof(TriggerWindow));
            m_TriggerWindow.Repaint();
            m_TriggerWindow.Show();
         
            needInit = true;
        }
        public static void WindowUpdate() {
            if (m_TriggerController != null)
                m_TriggerWindow.Repaint();
        }
        private void OnEnable() {
            Init();
        }
        void Init() {
            if (m_TriggerController != null) {
                serializedObject = new SerializedObject(m_TriggerController);
                SequenceProperty = serializedObject.FindProperty("Sequence");
                ActionLogicalOperators = serializedObject.FindProperty("ActionLogicalOperators");
                EndTypeProperty = serializedObject.FindProperty("EndType");
                NumberOfTriggerProperty = serializedObject.FindProperty("NumberOfOperator");
                EditorGUIUtilitySave();
                EventReorderableSetting();
                ActionReorderableSetting();
                needInit = false;
                selectActionList = new List<TriggerAction>();
            }
        }

        void EventReorderableSetting() {
            EventProperty = serializedObject.FindProperty("EventObjects");
            EventReorderable = new ReorderableList(serializedObject, EventProperty, true, true, true, true);
            EventReorderable.elementHeight = GetHeight(0);

            EventReorderable.drawHeaderCallback = (rect) => {
                EditorGUI.LabelField(rect, "이벤트");
            };
            //EventReorderable.onAddCallback = (list) => {
            //    EventData nullEvent = new EventData();

            //    triggerInspector.EventGroup.Add(nullEvent);
            //};
            // m_TriggerController.EventObjects = new List<TriggerEvent>();
            EventReorderable.elementHeight = GetHeight(0);
            EventReorderable.drawElementCallback = (rect, index, isActive, isFocused) => {
                if (index > m_TriggerController.EventObjects.Count)
                    return;

                EditorGUIUtilityReset();
                m_TriggerController.EventObjects[index].eventName = EditorGUI.TextField(rect,"이벤트 이름", m_TriggerController.EventObjects[index].eventName);
                //if (m_TriggerController.EventObjects[index].gameObject != null && m_TriggerController.EventObjects[index].eventName != null) {
                //    EditorGUIUtility.labelWidth = 100;
                //    rect.height = 20;
                //    string componentType = m_TriggerController.EventObjects[index].componentType;
                //    string eventName = m_TriggerController.EventObjects[index].eventName;
                //    EditorGUI.LabelField(rect, componentType);
                //    rect.x += 150;
                //    EditorGUI.LabelField(rect, eventName);
                //    rect.y += 20;
                //    rect.x -= 150;
                //    SerializedProperty SP = EventProperty.GetArrayElementAtIndex(index).FindPropertyRelative("gameObject");
                //    GUI.enabled = false;
                //    EditorGUI.PropertyField(rect, SP);
                //    GUI.enabled = true;
                //}
                //else {
                //    rect.height = GetHeight(1);
                //    if (GUI.Button(rect, new GUIContent("이벤트 찾기"))) {
                //        TriggerEventWindow.Open(m_TriggerController.EventObjects[index]);
                //    }
                //}
            };
            EventReorderable.drawElementBackgroundCallback = (rect, index, isActive, isFocused) => {
                rect.height *= 2;

            };
            EventReorderable.onAddCallback = (a) => {
                TriggerEvent triggerEvent = new TriggerEvent();
                m_TriggerController.EventObjects.Add(triggerEvent);
                //TriggerEventWindow.Open(triggerEvent);
            };
        }
        //void ConditionReorderableSetting() {
        //    ConditionProperty = serializedObject.FindProperty("Condition");
        //    ConditionReorderable = new ReorderableList(serializedObject, ConditionProperty, true, true, true, true);
        //    ConditionReorderable.onAddCallback = (list) => {
        //        triggerInspector.AddCondition(ScriptableObject.CreateInstance<TriggerCondition>(), false);
        //    };


        //    ConditionReorderable.drawElementCallback = (rect, index, isActive, isFocused) => {
        //        EditorGUIUtilityReset();
        //        if (triggerInspector.Condition[index].IfTrue) {
        //            EditorGUI.LabelField(rect, "IF");
        //            rect.x += 50;
        //            EditorGUI.LabelField(rect, triggerInspector.Condition[index].triggerCondition.ConditionText());
        //        }
        //        else {
        //            GUIStyle iftext = new GUIStyle();
        //            iftext.normal.textColor = Color.red;
        //            //GUIStyle conditionText = new GUIStyle(triggerInspector.Condition[index].triggerCondition.ConditionText());
        //            //iftext.normal.textColor = Color.black;
        //            EditorGUI.LabelField(rect, "IF NOT", iftext);
        //            rect.x += 50;
        //            EditorGUI.LabelField(rect, triggerContoroller.Condition[index].triggerCondition.ConditionText());
        //        }
        //    };
        //    ConditionReorderable.drawHeaderCallback = (rect) => {
        //        EditorGUI.LabelField(rect, "조건");
        //    };

        //}
        void ActionReorderableSetting() {
            SequenceProperty = serializedObject.FindProperty("Sequence");
            ActionReorderable = new ReorderableList(serializedObject, SequenceProperty, true, true, false, false);

            ActionReorderable.showDefaultBackground = true;

            ActionReorderable.elementHeight = GetHeight(4);
            ActionReorderable.drawElementCallback = (rect, index, isActive, isFocused) => {
                EditorGUIUtilityReset();
                TriggerAction trigger = m_TriggerController.GetTrigger(index);
                if (trigger == null)
                    return;

                float zeroLine = rect.y - ActionReorderable.elementHeight / 2 + 10;
                GUI.color = Color.white;
                int arrayLength = SequenceProperty.arraySize;
                rect.x -= 5;
                rect.y = zeroLine;
                EditorGUI.LabelField(rect, trigger.TriggerName);
                rect.y += 41;
                rect.height = 18;
                var triggerEditor = (TriggerActionEditor)Editor.CreateEditor(trigger);
                SerializedObject triggerSO = new SerializedObject(trigger);
                triggerEditor.OnTriggerEnable(triggerSO);
                triggerEditor.DrawGUI(triggerSO, rect);
                triggerSO.ApplyModifiedProperties();
            };
            ActionReorderable.drawElementBackgroundCallback = (rect, index, isActive, isFocused) => {
                if (index >= 0) {
                    GUI.color = Color.white;
                    if (Event.current.type == EventType.Repaint) {
                        rect.x = 0;
                        TriggerAction trigger = m_TriggerController.GetTrigger(index);
                        // 인스펙터 창 길이
                        rect.width = EditorGUIUtility.currentViewWidth;
                        rect.height = GetHeight(4);
                        rect.height -= space;
                        if (ActionReorderable.index != index) {
                            if (selectActionList.Contains(m_TriggerController.Sequence[index])) {
                                EditorGUI.DrawRect(rect, SelectColor * GetDefaultBackgroundColor());
                            }
                            else {
                                EditorGUI.DrawRect(rect, Color.white * GetDefaultBackgroundColor());
                            }
                        }
                        else {
                            EditorGUI.DrawRect(rect, SelectColor * GetDefaultBackgroundColor());
                        }
                    }
                }
            };
            ActionReorderable.drawHeaderCallback = (rect) => {
                GUI.color = Color.white;
                rect.width = EditorGUIUtility.currentViewWidth;
                rect.x = 0;
                rect.y += rect.height;
                rect.height = 20;
                rect.y -= 20;
                EditorGUI.DrawRect(rect, Color.gray * GetDefaultBackgroundColor());
                EditorGUI.LabelField(rect, "Action");
                // 뒷배경 제거
                GUI.color = new Color(1, 1, 1, 0);
            };
            ActionReorderable.onSelectCallback += (list) => {
                TriggerAction trigger = m_TriggerController.GetTrigger(list.index);
                if (Event.current.control) {
                    if (!selectActionList.Contains(trigger)) {
                        selectActionList.Add(trigger);
                    }                    
                }
                else {
                    selectActionList.Clear();
                    selectActionList.Add(trigger);
                }
            };
        }
        Vector2 vec2 = Vector2.zero;
        void OnGUI() {
            if (serializedObject == null)
                Init();
            if (needInit) {
                Init();
                needInit = false;
            }
            if(Event.current.control && Event.current.keyCode == KeyCode.C && Event.current.type == EventType.KeyUp) {
                copyTriggerAction = new List<TriggerAction>();
                for(int i = 0; i < selectActionList.Count; i++) {
                    if(selectActionList[i] != null) {
                        copyTriggerAction.Add(selectActionList[i].GetCopyTrigger());
                    }
                }
                Debug.Log("복사" + selectActionList.Count);
                m_TriggerWindow.Repaint();
            }
            if (Event.current.control && Event.current.keyCode == KeyCode.V && Event.current.type == EventType.KeyUp) {
                for (int i = copyTriggerAction.Count - 1; i >= 0; i--) {
                    if (copyTriggerAction[i] != null) {
                        if(0 <= ActionReorderable.index && ActionReorderable.index < m_TriggerController.Sequence.Count)
                        m_TriggerController.InsertTriggerAction(ActionReorderable.index + 1, copyTriggerAction[i].GetCopyTrigger());
                        else {
                            m_TriggerController.Sequence.Add(copyTriggerAction[i].GetCopyTrigger());
                        }
                    }
                }
                m_TriggerWindow.Repaint();
                Debug.Log("붙여넣기" + copyTriggerAction.Count);
            }
            if(Event.current.keyCode == KeyCode.Delete && Event.current.type == EventType.KeyUp) {
                DeleteAction();
            }
            if (SequenceProperty != null) {
                vec2 = EditorGUILayout.BeginScrollView(vec2, GUILayout.Height(position.height));
                EditorGUI.BeginChangeCheck();
                if (serializedObject != null)
                    serializedObject.Update();
                EditorGUIUtility.labelWidth = 100;
                EditorGUILayout.PropertyField(NumberOfTriggerProperty, new GUIContent("작동 횟수"));
                EditorGUILayout.PropertyField(EndTypeProperty, new GUIContent("끝내기 타입"));
                if (EventReorderable != null)
                    EventReorderable.DoLayoutList();

                EditorGUILayout.Space(50);
                if (ConditionReorderable != null)
                    ConditionReorderable.DoLayoutList();

                EditorGUILayout.Space(50);
                EditorGUIUtility.labelWidth = 100;
                EditorGUILayout.PropertyField(ActionLogicalOperators, new GUIContent("조건 체크 방식"));
                GUI.color = new Color(1, 1, 1, 0);

                // 트리거 액션 리스트
                if (SequenceProperty.arraySize > 0) {
                    ActionReorderable.DoLayoutList();
                }
                // 트리거 추가, 삭제
                GUI.color = new Color(1, 1, 1, 1);
                if (GUILayout.Button("AddTrigger")) {
                    AddTriggerWindow.Open(m_TriggerController.Sequence);
                }
                if (GUILayout.Button("Remove")) {
                    DeleteAction();
                }
                EditorGUI.EndChangeCheck();
                EditorGUILayout.EndScrollView();
            }

            if (m_TriggerController == null) {
                GUILayout.Label("선택 된 트리거가 없습니다.", EditorStyles.boldLabel);
                return;
            }
            serializedObject.ApplyModifiedProperties();
        }
        void DeleteAction() {
            if (selectActionList.Count > 1) {
            }
            else {
                if (ActionReorderable.index == -1) {
                    if (m_TriggerController.Sequence.Count > 0)
                        m_TriggerController.Sequence.RemoveAt(m_TriggerController.Sequence.Count - 1);
                }
                else {
                    m_TriggerController.Sequence.RemoveAt(ActionReorderable.index);
                    if (m_TriggerController.Sequence.Count == 0)
                        ActionReorderable.index = -1;
                    else if (m_TriggerController.Sequence.Count - 1 < ActionReorderable.index)
                        ActionReorderable.index = m_TriggerController.Sequence.Count - 1;
                }
            }
        }
        void EditorGUIUtilitySave() {
            labelWidth = EditorGUIUtility.labelWidth;
            fieldWidth = EditorGUIUtility.fieldWidth;
        }
        void EditorGUIUtilityReset() {
            EditorGUIUtility.labelWidth = labelWidth;
            EditorGUIUtility.fieldWidth = fieldWidth;
        }
        float GetHeight(int lineNum) {
            return (float)16 + (21 * lineNum) + space * lineNum;
        }
        Color GetInspectorColor(bool isPro) {
            if (isPro)
                return (Color)new Color32(56, 56, 56, 255);
            else
                return (Color)new Color32(194, 194, 194, 255);
        }
        private static Color GetDefaultBackgroundColor() {
            float kViewBackgroundIntensity = EditorGUIUtility.isProSkin ? 0.22f : 0.76f;
            return new Color(kViewBackgroundIntensity, kViewBackgroundIntensity, kViewBackgroundIntensity, 1f);
        }
    }
}