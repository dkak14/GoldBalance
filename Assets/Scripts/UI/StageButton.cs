using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StageButton : MonoBehaviour
{
    [SerializeField] string stage;
    [SerializeField] Button button;
    [SerializeField] Image image;
    [SerializeField] TextMeshProUGUI stageTMP;
    bool isJoin;
    public void Start() {
        StageData data = StageManager.Instance.GetStageData(stage);
        SetButton(stage, data.isJoin);
        button.onClick.AddListener(OnClick);
    }
    public void SetButton(string stage, bool isJoin) {
        stageTMP.text = stage;
        this.isJoin = isJoin;
        if (!isJoin) {
            Color color = image.color;
            image.color = new Color(color.r, color.g, color.b) * 0.6f;
        }
    }

    public void OnClick() {
        if (isJoin) {
            SceneLoader.Instance.SceneChange(stageTMP.text, new ScreenEffectData("Normal", 1, 1, false));
        }
    }
}
