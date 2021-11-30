using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class UnitAnimEditWindow : EditorWindow
{
    static UnitAnimEditWindow editWindow;
    static PlayerAnimController animController;
    Animator animator;
    SpriteRenderer spriteRenderer;

    int animControllerIndex = 0;
    int clipIndex = 0;
    int clipSpriteIndex = 0;
    string addDataName;
    SerializedProperty sampleWeaponProperty;
    public static void Open(PlayerAnimController animController) {
        UnitAnimEditWindow.animController = animController;
        if(editWindow == null) {
            editWindow = EditorWindow.CreateInstance<UnitAnimEditWindow>();
        }
        editWindow.Show();
    }

    private void OnEnable() {
    }
    private void OnGUI() {
        if (spriteRenderer == null) {
            animController.TryGetComponent(out spriteRenderer);
            animController.TryGetComponent(out animator);
            return;
        }
        GUIContent[] controllerContent = new GUIContent[animController.animControllerDatas.Count];
        for (int i = 0; i < controllerContent.Length; i++) {
            controllerContent[i] = new GUIContent(animController.animControllerDatas[i].type.ToString());
        }
        animControllerIndex = EditorGUILayout.Popup(new GUIContent("애니메이션"), animControllerIndex, controllerContent);
        animator.runtimeAnimatorController = animController.animControllerDatas[animControllerIndex].controller;

        List<PlayerAnimClipData> animDatas = animController.animControllerDatas[animControllerIndex].animDatas;
        AnimationClip[] clips = AnimationUtility.GetAnimationClips(animController.gameObject);
        for (int i = 0; i < clips.Length; i++) {
            for (int k = 0; k < animDatas.Count; k++) {
                if (animDatas[k].clipName == clips[i].name) {
                    continue;
                }
            }
            //   animController.animDatas.Add(new PlayerAnimData(clips[i].name));
        }
        if (animDatas.Count > 0) {
            GUIContent[] content = new GUIContent[animDatas.Count];
            for (int i = 0; i < content.Length; i++) {
                content[i] = new GUIContent(animDatas[i].clipName);
            }
            clipIndex = EditorGUILayout.Popup(new GUIContent("애니메이션"), clipIndex, content);

            AnimationClip findClip = null;
            PlayerAnimClipData playerAnimData = null;
            playerAnimData = animDatas[clipIndex];
            for (int i = 0; i < clips.Length; i++) {
                if (clips[i].name == animDatas[clipIndex].clipName) {
                    findClip = clips[i];
                }
            }

            if (findClip) {
                List<Sprite> spriteList = GetSpritesFromClip(findClip);
                GUIContent[] clipContent = new GUIContent[spriteList.Count];
                for (int i = 0; i < clipContent.Length; i++) {
                    clipContent[i] = new GUIContent(spriteList[i].name);

                    if (playerAnimData.clipDatas.Count < clipContent.Length) {
                        playerAnimData.clipDatas.Add(new PlayerAnimClipSpriteData());
                    }
                    playerAnimData.clipDatas[i].sprite = spriteList[i];
                }

                clipSpriteIndex = EditorGUILayout.Popup(new GUIContent("스프라이트"), clipSpriteIndex, clipContent);
                // 샘플 무기
                SerializedObject so = new SerializedObject(animController);
                sampleWeaponProperty = so.FindProperty("sampleWeapon");
                Debug.Log(sampleWeaponProperty != null);
                EditorGUILayout.PropertyField(sampleWeaponProperty, new GUIContent("샘플 무기"));
                so.ApplyModifiedProperties();
                // 스프라이트 데이터 설정
                PlayerAnimClipSpriteData playerAnimClipData = playerAnimData.clipDatas[clipSpriteIndex];
                playerAnimClipData.orderInLayer = EditorGUILayout.IntField("OrderInLayer", playerAnimClipData.orderInLayer);
                playerAnimClipData.weaponAngle = EditorGUILayout.FloatField("angle", playerAnimClipData.weaponAngle);
                playerAnimClipData.weaponOffset = EditorGUILayout.Vector2Field("offset", playerAnimClipData.weaponOffset);
                if (animController.sampleWeapon != null) {
                    animController.sampleWeapon.transform.position = (Vector2)animController.transform.position + playerAnimClipData.weaponOffset;
                    animController.sampleWeapon.transform.rotation = Quaternion.Euler(0, 0, playerAnimClipData.weaponAngle);
                    animController.sampleWeapon.sortingOrder = playerAnimClipData.orderInLayer;
                }


                spriteRenderer.sprite = spriteList[clipSpriteIndex];
            }
        }


        EditorGUILayout.Space(40);
        addDataName = EditorGUILayout.TextField("추가할 애니메이션", addDataName);
        if (GUILayout.Button("추가")) {
            animDatas.Add(new PlayerAnimClipData(addDataName));
        }
        if (GUILayout.Button("삭제")) {
            if (animDatas.Count > 0) {
                animDatas.RemoveAt(clipIndex);
            }
        }
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
}
