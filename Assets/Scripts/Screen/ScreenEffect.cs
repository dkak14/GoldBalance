using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScreenEffect : MonoBehaviour
{
    public abstract void FadeIn(float duration, float screenValue);
    public abstract void FadeOut(float duration, float screenValue);
}
