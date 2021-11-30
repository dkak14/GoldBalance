using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class SoundPage : MonoBehaviour, IInitialization
{
    [SerializeField] UIInputController uiInputController;
    [SerializeField] GameObject pageObject;
    float beforeTimeScale = 1;

    void OnEnable() {
        uiInputController.GetInputAction("ESC").inputAction.started += OpenPage;
    }
    void OnDisable() {
        uiInputController.GetInputAction("ESC").inputAction.started -= OpenPage;
    }
    public void CancleButton() {
        Close();
    }
    public void ExitGame() {
        Application.Quit();
    }
    void OpenPage(InputAction.CallbackContext context) {
        if(pageObject.activeSelf == false) {
            Open();
        }
        else {
            Close();
        }
    }
    void Open() {
        if (pageObject.activeSelf == false) {
            pageObject.gameObject.SetActive(true);
            beforeTimeScale = Time.timeScale;
            Time.timeScale = 0;
        }
    }
    void Close() {
        if (pageObject.activeSelf == true) {
            pageObject.gameObject.SetActive(false);
            Time.timeScale = beforeTimeScale;
        }
    }
    public void Initialization() {
       // uiInputController.GetInputAction("ESC").inputAction.started += OpenPage;
    }
}
