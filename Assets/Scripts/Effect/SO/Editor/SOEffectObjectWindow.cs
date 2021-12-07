using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
public class SOEffectObjectWindow : EditorWindow
{
    public static SOEffectObjectWindow window;
    public static SOEffectObject soEffectData;
    static SerializedObject soSerializedObject;
    static SerializedProperty listProperty;
    static ReorderableList reorderableList;
    public static void Open(SOEffectObject soData) {
        soEffectData = soData;
        soSerializedObject = new SerializedObject(soEffectData);
        listProperty = soSerializedObject.FindProperty("effectObjectDataList");
        if (window == null)
        window = CreateWindow<SOEffectObjectWindow>();
        ListInit();
        window.Show();
    }
   static void ListInit() {
        reorderableList = new ReorderableList(soSerializedObject, listProperty,true, true, true, true);
        reorderableList.drawHeaderCallback = (rect) => {
            EditorGUI.LabelField(rect, "이펙트 리스트");
        };
        reorderableList.elementHeight = 90;
        reorderableList.drawElementCallback = (rect, index, isActive, isFocused) => {
            rect.height = 18;
            EditorGUI.PropertyField(rect, listProperty.GetArrayElementAtIndex(index).FindPropertyRelative("id"),new GUIContent("ID"));
            rect.y += 18;
            EditorGUI.PropertyField(rect, listProperty.GetArrayElementAtIndex(index).FindPropertyRelative("effect"), new GUIContent("Effect"));
            if(soEffectData.effectObjectDataList[index].effect != null) {

                if(soEffectData.effectObjectDataList[index].effect.anim == null) {
                    soEffectData.effectObjectDataList[index].effect.TryGetComponent(out soEffectData.effectObjectDataList[index].effect.anim);
                }
                AnimationClip[] clips = soEffectData.effectObjectDataList[index].effect.anim.runtimeAnimatorController.animationClips;
                AnimationClip clip = clips[0];
                List<Sprite> spriteList = GetSpritesFromClip(clip);

                rect.height = 32;
                rect.width = 32;
                rect.y += 18;
                for (int i = 0;i < spriteList.Count; i++) {
                    EditorGUI.DrawPreviewTexture(rect, spriteList[i].texture, soEffectData.previewMaterial);
                    rect.x += 32;
                }
            }
        };
    }
    static List<Sprite> GetSpritesFromClip(AnimationClip clip) {
        var sprites = new List<Sprite>();
        if (clip != null) {
            foreach (var binding in AnimationUtility.GetObjectReferenceCurveBindings(clip)) {
                var keyframes = AnimationUtility.GetObjectReferenceCurve(clip, binding);
                foreach (var frame in keyframes) {
                    sprites.Add((Sprite)frame.value);
                }
            }
        }
        return sprites;
    }

    void OnGUI() {
        if (soSerializedObject == null || soEffectData == null)
            window.Close();
        reorderableList.DoLayoutList();
        soSerializedObject.ApplyModifiedProperties();
    }
}
