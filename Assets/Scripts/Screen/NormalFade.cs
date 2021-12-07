using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class NormalFade : ScreenEffect {
    [SerializeField] Image image;
    public override void FadeIn(float duration, float screenValue) {
        Color color = image.color;
        image.color = new Color(color.r, color.g, color.b, 1);
        image.DOColor(new Color(color.r, color.g, color.b, 0), duration);
    }

    public override void FadeOut(float duration, float screenValue) {
        Color color = image.color;
        image.color = new Color(color.r, color.g, color.b, 0);
        image.DOColor(new Color(color.r, color.g, color.b, 1), duration);
    }
}
