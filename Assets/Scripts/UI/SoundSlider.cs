using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundSlider : MonoBehaviour
{
    [SerializeField] SoundType soundType;
    [SerializeField] Slider slider;
    void Start()
    {
        slider.onValueChanged.AddListener(OnValueChanged);
        slider.value = SoundManager.Instance.GetVoulme(soundType);
    }
    void OnValueChanged(float value) {
        SoundManager.Instance.SetVolume(soundType, value);
    }
}
