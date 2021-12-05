using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NPC : UnitControllerBase
{
    [Header("상호작용 이벤트 이름")]
    public string InteractionEventID;
    public event Action InteractionEvent;

    public void Interaction() {
        EventManager.Instance.TriggerEventMessage(InteractionEventID);
    }
}
