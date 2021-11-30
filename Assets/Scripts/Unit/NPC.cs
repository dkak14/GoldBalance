using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class NPC : UnitControllerBase
{
    [Header("��ȣ�ۿ� �̺�Ʈ �̸�")]
    public string InteractionEventID;
    public event Action InteractionEvent;

    protected override void Start() {
        base.Start();
        EventManager.Instance.TriggerEventMessage(InteractionEventID);
    }
    public void Interaction() {
        if(InteractionEvent != null) {
            EventManager.Instance.TriggerEventMessage(InteractionEventID);
        }
    }
}
