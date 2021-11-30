using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Text;
public class AcDialogWindow : EditorWindow
{
    static AcDialogWindow window;
    static SerializedObject dialogOwner;
    static SerializedProperty dialogProperty;
    static SerializedProperty dialogDataListProperty;
    static SODialogData soDialogData;
    SerializedObject soDialogDataObject;
    SerializedProperty selectItem;
    SerializedProperty remainingTimeProperty;
    SerializedProperty typingStartProperty;
    SerializedProperty typingEndProperty;

    ReorderableList dialogDataOrderList;

    Vector2 scrollPos;
    public static void Open(SerializedObject dialogOwner,SerializedProperty dialogProperty, SODialogData soDialogData) {
        AcDialogWindow.dialogOwner = dialogOwner;
        AcDialogWindow.dialogProperty = dialogProperty;
        AcDialogWindow.soDialogData = soDialogData;
        dialogDataListProperty = dialogProperty.FindPropertyRelative("dialogDatas");
        if (window == null) {
            window = CreateInstance<AcDialogWindow>();
        }
        window.Show();
    }
    private void OnEnable() {
        soDialogDataObject = new SerializedObject(soDialogData);

        dialogDataOrderList = new ReorderableList(dialogOwner, dialogDataListProperty,true, true, true, true);
        dialogDataOrderList.drawElementCallback = (rect, index, active, focused) => {
           SerializedProperty item = dialogDataListProperty.GetArrayElementAtIndex(index);
            DialogData dialogData = soDialogData.GetDialog(item.FindPropertyRelative("id").intValue);
            string text = dialogData.dialog;
            EditorGUI.LabelField(rect, text);
        };
        dialogDataOrderList.drawElementBackgroundCallback = (rect, index, active, focused) => {
            if(index == dialogDataOrderList.index) {
               EditorGUI.DrawRect(rect, new Color(0.403f, 0.6f, 1));
            }
        };
        dialogDataOrderList.drawHeaderCallback = (rect) => {
            EditorGUI.LabelField(rect, "대화 목록");
        };
    }
    private void OnGUI() {
        //GUILayout.BeginScrollView( new Vector2(0,0));
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(200), GUILayout.Height(position.height));
        dialogDataOrderList.DoLayoutList();
        EditorGUILayout.EndScrollView();
        if (dialogDataOrderList.index >= 0)
            selectItem = dialogDataListProperty.GetArrayElementAtIndex(dialogDataOrderList.index);
        if (selectItem != null)
            DrawDialogElement(new Rect(200, 0, EditorGUIUtility.currentViewWidth - 200, EditorGUIUtility.singleLineHeight));
    }


    void DrawDialogElement(Rect position) {
        Undo.RecordObject(dialogOwner.targetObject, "ValueChange");
        dialogOwner.Update();
        SerializedProperty idProperty = selectItem.FindPropertyRelative("id");
        DialogData dialogData = soDialogData.GetDialog(idProperty.intValue);
        idProperty.intValue = EditorGUI.IntField(position, new GUIContent("대사 아이디"), idProperty.intValue);
        position.y += 18;

        EditorGUI.LabelField(position, new GUIContent("이미지 아이디 : " + dialogData.imageID));
        position.y += 18;

        string characterName = soDialogData.GetCharacterData(dialogData.characterID).name;
        StringBuilder builder = new StringBuilder();
        builder.Append("캐릭터 아이디 : ");
        builder.Append(dialogData.characterID);
        builder.Append('(');
        builder.Append(characterName);
        builder.Append(')');
        EditorGUI.LabelField(position, new GUIContent(builder.ToString()));
        position.y += 18;

        remainingTimeProperty = selectItem.FindPropertyRelative("remainingTime");
        remainingTimeProperty.floatValue = EditorGUI.FloatField(position, "잔류 시간", remainingTimeProperty.floatValue);
        

        remainingTimeProperty.floatValue = Mathf.Max(0, remainingTimeProperty.floatValue);
        position.y += 18;

        typingStartProperty = selectItem.FindPropertyRelative("typingStartEvent");
        typingStartProperty.stringValue = EditorGUI.TextField(position, "타이핑 시작 이벤트 ", typingStartProperty.stringValue);
        position.y += 18;

        typingEndProperty = selectItem.FindPropertyRelative("typingEndEvent");
        typingEndProperty.stringValue = EditorGUI.TextField(position, "타이핑 완료 이벤트 ", typingEndProperty.stringValue);
        position.y += 18;

        EditorGUI.LabelField(position, new GUIContent("대사"));
        position.y += 18;

        EditorGUI.DrawRect(position, new Color(0.9f, 0.9f, 0.9f));
        EditorGUI.LabelField(position, new GUIContent(dialogData.dialog));

        soDialogDataObject.ApplyModifiedProperties();
        dialogOwner.ApplyModifiedProperties();
    }
}
