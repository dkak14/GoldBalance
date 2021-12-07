using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using DG.Tweening;

public class ScreenManager : SingletonBehaviour<ScreenManager>
{
    [SerializeField] Transform canvas;
    [SerializeField] SOScreenEffect soScreenEffect;
    
    public Dictionary<string, ScreenObjectData> screenDataDic;
    public override void Awake()
    {
        base.Awake();
        screenDataDic = new Dictionary<string, ScreenObjectData>();
        List<SOScreenEffect.ScreenData> screenDataList = soScreenEffect.screenDataList;

        for(int i = 0;i < screenDataList.Count; i++) {
            ScreenObjectData data = new ScreenObjectData();
            data.effectPrefab = screenDataList[i].effect;
            data.effectObject = null;

            screenDataDic.Add(screenDataList[i].ID, data);
        }
    }

    private void Start() {
        //SetActiveScreenEffect(startFade, duration, 1, true);
        //SetActiveScreenEffect("LetterBox", duration, 0.2f, false);
    }
    public void SetActiveScreenEffect(string id, float duration, float screenValue, bool fadeIn) {
        ScreenObjectData data;
        if(!screenDataDic.TryGetValue(id, out data)) {
            Debug.Log(id + "스크린은 없다");
            return;
        }
        if (data.effectObject != null) {
            ScreenEffect effectObject = data.effectObject;
            effectObject.DOKill();
            Destroy(effectObject.gameObject);
            data.effectObject = null;
            Debug.Log("삭제");
        }
        if (data.effectObject == null) {
            ScreenEffect effectObject = Instantiate(data.effectPrefab, canvas);
            data.effectObject = effectObject;
        }
        ScreenEffect effect = data.effectObject;
        effect.DOKill();

        if (fadeIn) {
            effect.FadeIn(duration, screenValue);
            Debug.Log("페이드 인");
        }
        else {
            effect.FadeOut(duration, screenValue);
            Debug.Log("페이드 아웃");
        }
    }
    public void SceneChange(string scene, string id, float duration, float screenValue) {
        ScreenObjectData data;
        if (!screenDataDic.TryGetValue(id, out data)) {
            Debug.Log(id + "스크린은 없다");
            return;
        }
        ScreenEffect effectObject =Instantiate(data.effectPrefab, canvas);
        effectObject.FadeOut(duration, screenValue);
        StartCoroutine(C_Timer(scene, duration));
    }
    IEnumerator C_Timer(string scene, float time) {
        yield return new WaitForSeconds(time + 0.1f);
        SceneManager.LoadScene(scene);
    }
    public class ScreenObjectData {
        public ScreenEffect effectPrefab;
        public ScreenEffect effectObject;
    }
}
