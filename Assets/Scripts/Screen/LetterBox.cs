using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class LetterBox : ScreenEffect
{
    [SerializeField] Image upImage;
    [SerializeField] Image downImage;
    public override void FadeIn(float duration, float screenValue) {
        float screenHeight = Screen.height;

        float moveHeight = (screenHeight * 0.5f) * screenValue;
        Vector3 upOutPos = upImage.rectTransform.position + Vector3.up * screenHeight;
        Vector3 downOutPos = downImage.rectTransform.position + Vector3.up * -screenHeight;
        upImage.rectTransform.position = upOutPos + Vector3.up * -moveHeight;
        downImage.rectTransform.position = downOutPos + Vector3.up * +moveHeight;

        upImage.transform.DOMoveY(upOutPos.y, duration);
        downImage.transform.DOMoveY(downOutPos.y, duration);
    }

    public override void FadeOut(float duration, float screenValue) {
        float screenHeight = Screen.height;

        upImage.rectTransform.position += Vector3.up * screenHeight;
        downImage.rectTransform.position += Vector3.up * -screenHeight;

        float moveHeight = (screenHeight * 0.5f) * screenValue;
        upImage.transform.DOMoveY(upImage.transform.position.y + -moveHeight, duration);
        downImage.transform.DOMoveY(downImage.transform.position.y + moveHeight, duration);
    }
}
