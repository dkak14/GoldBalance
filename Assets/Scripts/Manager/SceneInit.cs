using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneInit : MonoBehaviour
{
    void Awake() {
        Scene activeScene = SceneManager.GetActiveScene();
        for(int i = 0; i < SceneManager.sceneCount; i++) {
            if (SceneManager.GetSceneAt(i).name == "SceneLoader")
                return;
        }
        SceneManager.LoadScene("SceneLoader", LoadSceneMode.Additive);
    }

}
