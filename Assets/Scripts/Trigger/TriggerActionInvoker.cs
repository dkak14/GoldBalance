using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Triggers;
using System;
public class TriggerActionInvoker : MonoBehaviour {
    List<TriggerAction> ActionTriggers;
    List<TriggerAction> InitTriggers;
    bool isContinue = false;

    public event Action ActionCycleEnd;
    public void StartAction(List<TriggerAction> ActionList, bool Continue, Action callback) {
        InitTriggers = ActionList;
        ActionTriggers = new List<TriggerAction>(InitTriggers.Count);
        for (int i = 0; i < InitTriggers.Count; i++) {
            TriggerAction trigger = InitTriggers[i].GetCopyTrigger();
            ActionTriggers.Add(trigger);
        }
        isContinue = Continue;
        StartCoroutine(C_Action(callback));
    }
    public void StartAction(List<TriggerAction> ActionList, bool Continue) {
        StartAction(ActionList, Continue, null);
    }
    void Init() {
        for (int i = 0; i < InitTriggers.Count; i++) {
            TriggerAction trigger = InitTriggers[i].GetCopyTrigger();
            ActionTriggers[i] = trigger;
        }
    }
    IEnumerator C_Action(Action callback) {
        while (true) {
            int i = 0;
            Init();
            while (true) {
                if (i < ActionTriggers.Count) {
                    if (ActionTriggers[i].Action()) {
                        i++;
                    }
                    yield return null;
                }
                else
                    break;
            }
            if (isContinue)
                continue;
            else
                break;
        }
        if (callback != null)
            callback();
        if(ActionCycleEnd != null) {
            ActionCycleEnd();
        }
        Destroy(gameObject);
    }
}