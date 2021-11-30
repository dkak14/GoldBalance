using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Triggers;
using System.Text.RegularExpressions;
namespace Triggers {
    public class AddTriggerWindow : EditorWindow {
        static AddTriggerWindow m_AddTriggerWindow;
        static List<TriggerAction> m_Triggers;
        static string searchText;
        static string beforeSearchText;
        List<TriggerDirectory> m_TriggerDirectorys;
        bool start = false;

        Vector2 vec2 = Vector2.zero;
        List<DisplayTriggerAction> displayTriggers = new List<DisplayTriggerAction>();
        public static void Open(List<TriggerAction> triggerList) {
            searchText = "";
            beforeSearchText = "";
            if (m_AddTriggerWindow == null) {
                m_AddTriggerWindow = CreateInstance<AddTriggerWindow>();
            }
            m_Triggers = triggerList;
            m_AddTriggerWindow.Show();
        }
        private void OnGUI() {
            if (!start) {
                TriggerListInit();
                SearchTriggers();
                start = true;
            }
            if (m_Triggers == null || m_TriggerDirectorys == null) {
                m_AddTriggerWindow.Close();
            }
            if (Event.current.keyCode == KeyCode.Escape) {
                m_AddTriggerWindow.Close();
            }
            searchText = EditorGUILayout.TextField(searchText);
            vec2 = EditorGUILayout.BeginScrollView(vec2, GUILayout.Height(position.height));
            EditorGUI.BeginChangeCheck();

            if (beforeSearchText != searchText) {
                SearchTriggers();
                beforeSearchText = searchText;
            }
            DisplayTriggers();
            EditorGUI.EndChangeCheck();
            EditorGUILayout.EndScrollView();
        }
        void SearchTriggers() {
            if (m_Triggers != null) {
                displayTriggers.Clear();
                for (int DirectoryIndex = 0; DirectoryIndex < m_TriggerDirectorys.Count; DirectoryIndex++) {
                    List<TriggerAction> DirectoryTriggers = m_TriggerDirectorys[DirectoryIndex].GetTriggers();
                    // 디렉토리 이름
                    string directoryName = m_TriggerDirectorys[DirectoryIndex].DirectoryName;
                    displayTriggers.Add(new DisplayTriggerAction(directoryName));
                    // 디렉토리 내부 트리거 문자 매치
                    for (int TriggerIndex = 0; TriggerIndex < DirectoryTriggers.Count; TriggerIndex++) {
                        string triggerName = DirectoryTriggers[TriggerIndex].TriggerName;
                        Regex regex = new Regex(searchText, RegexOptions.IgnoreCase);
                        Match match = regex.Match(triggerName);
                        if (match.Success) {
                            TriggerAction trigger = DirectoryTriggers[TriggerIndex].GetCopyTrigger();
                            displayTriggers[displayTriggers.Count - 1].Triggers.Add(trigger);
                        }
                    }
                }
            }
            else
                m_AddTriggerWindow.Close();
        }
        void DisplayTriggers() {
            if (m_Triggers == null) {
                m_AddTriggerWindow.Close();
                return;
            }
            for (int directoryIndex = 0; directoryIndex < displayTriggers.Count; directoryIndex++) {
                if (displayTriggers[directoryIndex].Triggers.Count > 0) {
                    string directoryName = displayTriggers[directoryIndex].DirectoryName;
                    EditorGUILayout.LabelField(directoryName);
                }
                List<TriggerAction> displayTriggerList = displayTriggers[directoryIndex].Triggers;
                for (int index = 0; index < displayTriggerList.Count; index++) {
                    string triggerName = displayTriggerList[index].TriggerName;
                    if (GUILayout.Button(triggerName)) {
                        Debug.Log(triggerName + " 트리거 생성 ");
                        TriggerAction trigger = displayTriggerList[index].GetCopyTrigger();
                        trigger.name = "Ac" + trigger.TriggerName;
                        m_Triggers.Add(trigger);
                    }
                }
            }
        }
        void TriggerListInit() {
            m_TriggerDirectorys = TriggerUtility.GetTriggerDirectorys();
        }

        struct DisplayTriggerAction {
            public string DirectoryName;
            public List<TriggerAction> Triggers;

            public DisplayTriggerAction(string directoryName) {
                DirectoryName = directoryName;
                Triggers = new List<TriggerAction>();
            }
        }
    }
}
