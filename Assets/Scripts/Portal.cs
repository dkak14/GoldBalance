using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] string sceneName;
    [SerializeField] string fadeEffect = "Normal";
    [SerializeField] float duration = 1;

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            SceneLoader.Instance.SceneChange(sceneName, new ScreenEffectData(fadeEffect, duration, 1, true));
        }
    }
}
