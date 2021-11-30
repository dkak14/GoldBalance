using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerInputController : MonoBehaviour, IInitialization
{
    PlayerInput playerInput;
    Dictionary<string, MyInputAction> myInputActionDIc;

    public event System.Action testEvent = delegate { };
    protected virtual void Awake() {
        Initialization();
    }
    protected virtual void OnEnable() {
        playerInput.Enable();
    }
    protected virtual void OnDisable() {
        playerInput.Disable();
    }
    public MyInputAction GetInputAction(string id) {
        MyInputAction inputAction;
        if (myInputActionDIc.TryGetValue(id, out inputAction)) {
            return inputAction;
        }
        else {
            Debug.LogWarning($"{id}라는 인풋은 없습니다");
            return null;
        }
    }
    public virtual void Initialization() {
        playerInput = new PlayerInput();
        myInputActionDIc = new Dictionary<string, MyInputAction>();
        myInputActionDIc.Add("Horizental", new MyInputAction(playerInput.Axis.Horizontal));
        myInputActionDIc.Add("Vertical", new MyInputAction(playerInput.Axis.Vertical));
        myInputActionDIc.Add("LeftClick", new MyInputAction(playerInput.Mouse.Left));
        myInputActionDIc.Add("RightClick", new MyInputAction(playerInput.Mouse.Right));
        myInputActionDIc.Add("MiddleClick", new MyInputAction(playerInput.Mouse.Middle));
        myInputActionDIc.Add("Space", new MyInputAction(playerInput.KeyBoard.Space));
        myInputActionDIc.Add("K", new MyInputAction(playerInput.KeyBoard.K));
        myInputActionDIc.Add("L", new MyInputAction(playerInput.KeyBoard.L));
        myInputActionDIc.Add("R", new MyInputAction(playerInput.KeyBoard.R));
        myInputActionDIc.Add("Q", new MyInputAction(playerInput.KeyBoard.Q));
        myInputActionDIc.Add("F", new MyInputAction(playerInput.KeyBoard.F));
        myInputActionDIc.Add("S", new MyInputAction(playerInput.KeyBoard.S));
        myInputActionDIc.Add("1", new MyInputAction(playerInput.KeyBoard._1));
        myInputActionDIc.Add("2", new MyInputAction(playerInput.KeyBoard._2));

        GetInputAction("K").inputAction.started += (con) => { testEvent(); };
    }
}
public class MyInputAction {
    public InputAction inputAction;
    public InputActionLog startedLog;
    public InputActionLog performedLog;
    public InputActionLog cancledLog;
    public MyInputAction(InputAction inputAction) {
        this.inputAction = inputAction;
        startedLog = new InputActionLog(0, 0);
        performedLog = new InputActionLog(0, 0);
        cancledLog = new InputActionLog(0, 0);

        this.inputAction.started += UpdateStartedLog;
        this.inputAction.performed += UpdatePerformedLog;
        this.inputAction.canceled += UpdateCancledLog;
    }
    void UpdateStartedLog(InputAction.CallbackContext context) {
        startedLog.previousInputTime = startedLog.currentlyInputTime;
        startedLog.currentlyInputTime = Time.time;
    }
    void UpdatePerformedLog(InputAction.CallbackContext context) {
        performedLog.previousInputTime = performedLog.currentlyInputTime;
        performedLog.currentlyInputTime = Time.time;
    }
    void UpdateCancledLog(InputAction.CallbackContext context) {
        cancledLog.previousInputTime = cancledLog.currentlyInputTime;
        cancledLog.currentlyInputTime = Time.time;
    }
    public struct InputActionLog {
        public float previousInputTime;
        public float currentlyInputTime;
        public InputActionLog(float previousInputTime, float currentlyInputTime) {
            this.previousInputTime = previousInputTime;
            this.currentlyInputTime = currentlyInputTime;
        }
    }
}