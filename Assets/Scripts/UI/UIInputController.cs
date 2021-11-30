using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputController : MonoBehaviour, IInitialization {
    UIInput uiInput;
    Dictionary<string, MyInputAction> myInputActionDIc;
    protected virtual void Awake() {
        Initialization();
    }
    protected virtual void OnEnable() {
        uiInput.Enable();
    }
    protected virtual void OnDisable() {
        uiInput.Disable();
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
        uiInput = new UIInput();
        myInputActionDIc = new Dictionary<string, MyInputAction>();
        myInputActionDIc.Add("ESC", new MyInputAction(uiInput.KeyBoard.ESC));
        myInputActionDIc.Add("LeftClick", new MyInputAction(uiInput.Mouse.Left));
        myInputActionDIc.Add("RightClick", new MyInputAction(uiInput.Mouse.Right));
    }
}
