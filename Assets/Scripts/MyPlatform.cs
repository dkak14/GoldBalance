using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MyPlatform : MonoBehaviour
{
    PlayerInput input;
    PlatformEffector2D platformObject;

    void Awake() {
        platformObject = GetComponent<PlatformEffector2D>();
        input = new PlayerInput();
        input.KeyBoard.S.started += InputS;
        input.KeyBoard.Space.started += InputJump;
    }
    private void OnEnable() {
        input.Enable();
    }
    private void OnDisable() {
        input.Disable();
    }
    private void OnDestroy() {
        input.KeyBoard.S.started -= InputS;
        input.KeyBoard.Space.started -= InputJump;
    }
    void InputS(InputAction.CallbackContext context) {
        Debug.Log("에스");
        platformObject.rotationalOffset = 180f;
    }
    void InputJump(InputAction.CallbackContext context) {
        Debug.Log("점프");
        platformObject.rotationalOffset = 0f;
    }
}
