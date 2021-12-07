using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    bool changeScene;
    public void SceneChange(string sceneID, ScreenEffectData effectData) {
        if (Application.CanStreamedLevelBeLoaded(sceneID)) {
            if(!changeScene)
            StartCoroutine(C_SceneChange(sceneID, effectData));
        }
        else {
            Debug.LogError($"{sceneID}라는 씬은 존재하지 않습니다");
        }
    }
    IEnumerator C_SceneChange(string sceneID, ScreenEffectData effectData) {
        if (!changeScene) {
            changeScene = true;
            EventManager.Instance.SceneChangeStart(sceneID);
            ScreenManager.Instance.SetActiveScreenEffect(effectData.id, effectData.duration, effectData.screenValue, false);
            Scene activeScene = SceneManager.GetActiveScene();
            yield return new WaitForSeconds(effectData.duration);
            AsyncOperation deActiveAO = SceneManager.UnloadSceneAsync(activeScene);
            while (!deActiveAO.isDone) {
                yield return null;
            }

            AsyncOperation ao = SceneManager.LoadSceneAsync(sceneID, LoadSceneMode.Additive);
            while (!ao.isDone) {
                yield return null;
            }
            Scene nowScene = SceneManager.GetSceneByName(sceneID);
            SceneManager.SetActiveScene(nowScene);
            ScreenManager.Instance.SetActiveScreenEffect(effectData.id, effectData.duration, effectData.screenValue, true);
            EventManager.Instance.SceneChangeEnd();
            changeScene = false;
        }
    }
}
public struct ScreenEffectData {
    public string id;
    public float duration;
    public float screenValue;
    public bool fadeIn;

    public ScreenEffectData(string id, float duration, float screenValue, bool fadeIn) {
        this.id = id;
        this.duration = duration;
        this.screenValue = screenValue;
        this.fadeIn = fadeIn;
    }
}