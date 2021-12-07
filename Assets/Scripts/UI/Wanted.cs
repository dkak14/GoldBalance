using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;
public class Wanted : MonoBehaviour
{
    [SerializeField] bool anykeyDisable;
    [SerializeField] string diableEventID;
    public int textID;
    bool frame;
    private void Update() {
        if (anykeyDisable && Keyboard.current.anyKey.wasPressedThisFrame && frame) {
            gameObject.SetActive(false);
        }
        if (!frame)
            frame = true;
    }
    private void OnEnable() {
        EventManager.Instance.SetActiveCutScene(true);
        //UnitControllerBase unit = UnitManager.Instance.GetUnit("Player");
        //UnitMoveControllerBase playerMove;
        //if(unit && unit.TryGetComponent(out playerMove)){
        //    playerMove.isMove = false;
        //    playerMove.isJump = false;
        //}
        frame = false;
    }

    private void OnDisable() {
        EventManager.Instance.SetActiveCutScene(false);
        if(diableEventID != "") {
            EventManager.Instance.TriggerEventMessage(diableEventID);
        }
        //UnitControllerBase unit = UnitManager.Instance.GetUnit("Player");
        //UnitMoveControllerBase playerMove;
        //if (unit && unit.TryGetComponent(out playerMove)){
        //    playerMove.isMove = true;
        //    playerMove.isJump = true;
        //}
        frame = true;
    }
}
