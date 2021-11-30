using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMoveController : UnitMoveControllerBase {
    PlayerInputController inputController;
    PlayerController playerController;
    Coroutine moveRoutine;
    Animator animator;
    bool move;
    private void Update() {
        if (Time.timeScale != 0) {
            if (move && isMove) {
                animator.SetBool("isMove", true);
            }
            else {
                animator.SetBool("isMove", false);
            }
        }
    }
    private void StartedInputMove(InputAction.CallbackContext context) {
        if(moveRoutine != null) {
            StopCoroutine(moveRoutine);
            moveRoutine = null;
        }
        moveRoutine = StartCoroutine(C_InputMove(context.ReadValue<float>()));
        move = true;
    }
    private void PerformedInputMove(InputAction.CallbackContext context) {
    }
    private void CanceledInputMove(InputAction.CallbackContext context) {
        if (moveRoutine != null) {
            StopCoroutine(moveRoutine);
            move = false;
            moveRoutine = null;
        }
    }
    IEnumerator C_InputMove(float axis) {
        WaitForFixedUpdate fixedUpdate = new WaitForFixedUpdate();
        while (true) {
            Move(axis);
            yield return fixedUpdate;
        }
    }
    void JumpInput(InputAction.CallbackContext context) {
        Jump(jumpPower);
        
    }
    void JumpAnim(bool onPlatform) {
        if (onPlatform) {
            animator.SetBool("isJump", false);
        }
        else {
            animator.SetBool("isJump", true);
        }
    }
    void FallPlatform(InputAction.CallbackContext context) {
        DownPlatform();
    }
    private void OnDisable() {
        inputController.GetInputAction("Horizental").inputAction.started -= StartedInputMove;
        inputController.GetInputAction("Horizental").inputAction.performed -= PerformedInputMove;
        inputController.GetInputAction("Horizental").inputAction.canceled -= CanceledInputMove;
        inputController.GetInputAction("Space").inputAction.started -= JumpInput;
        inputController.GetInputAction("S").inputAction.started -= FallPlatform;
    }
    public override void Initialization() {
        base.Initialization();
        TryGetComponent(out inputController);
        TryGetComponent(out playerController);
        TryGetComponent(out animator);
        inputController.GetInputAction("Horizental").inputAction.started += StartedInputMove;
        inputController.GetInputAction("Horizental").inputAction.performed += PerformedInputMove;
        inputController.GetInputAction("Horizental").inputAction.canceled += CanceledInputMove;
        inputController.GetInputAction("Space").inputAction.started += JumpInput;
        inputController.GetInputAction("S").inputAction.started += FallPlatform;

        playerController.OnPlatform += JumpAnim;
    }
}
