using System.Collections.Generic;
using UnityEngine;
using System;
using System.Reflection;
using Triggers;
public enum LogicalOperators {
    AND, OR
}
public enum NumberOfTrigger {
    ONCE, CONTINUE
}
public enum TriggerEndType {
    FINISH_AND_DIE, FINISH_AND_RESTART
}
namespace Triggers {
    [Serializable]
    public class TriggerCondition {
        bool ifTrue = true;
        public bool IfTrue { get { return ifTrue; } }
        public TriggerCondition triggerCondition = null;
        public TriggerCondition(TriggerCondition condition, bool ifTrue) {
            triggerCondition = condition;
            this.ifTrue = ifTrue;
        }
    }
    [System.Serializable]
    public class TriggerEvent {
        //public Component gameObject;
        //public string componentType;
        public string eventName;
    }
    public class TriggerController : MonoBehaviour {
        //[SerializeField] public string TriggerEventName;
        [SerializeField] public List<TriggerEvent> EventObjects = new List<TriggerEvent>(0);
        [SerializeField] List<TriggerCondition> Condition;
        [SerializeField] NumberOfTrigger NumberOfOperator = NumberOfTrigger.ONCE;
        [SerializeField] TriggerEndType EndType = TriggerEndType.FINISH_AND_DIE;
        [SerializeField] LogicalOperators ActionLogicalOperators = LogicalOperators.AND;
        [SerializeField] public List<TriggerAction> Sequence = new List<TriggerAction>();

        bool StartOnce = false;

        public event Action TriggerActionCicleEnd;

        public int instanceID;
        private void Awake() {
            EventManager.Instance.TriggerEventMessage += InvokeAction;
            for (int i = 0; i < EventObjects.Count; i++) {
                //if (EventObjects[i].gameObject != null) {
                //    //Debug.Log(EventObjects[i].eventName);
                //    //Debug.Log(EventObjects[i].gameObject.GetType());
                //    string eventName = EventObjects[i].eventName;

                //    EventInfo eInfo = EventObjects[i].gameObject.GetType().GetEvent(eventName);
                //    Type handlerType = eInfo.EventHandlerType;

                //    MethodInfo eventHandler = this.GetType().GetMethod("InvokeAction", BindingFlags.Public | BindingFlags.Instance);
                //    Delegate myhandler = Delegate.CreateDelegate(handlerType, this, eventHandler);
                //    eInfo.AddEventHandler(EventObjects[i].gameObject, myhandler);
                //}
            }
        }
        private void OnDestroy() {
            EventManager.Instance.TriggerEventMessage -= InvokeAction;
        }
        public TriggerAction GetTrigger(int index) {
            return Sequence[index];
        }
        public void InsertTriggerAction(int index, TriggerAction action) {
            Sequence.Insert(index, action);
        }
        public void InvokeAction(string eventName) {
            bool find = false;
            for (int i = 0; i < EventObjects.Count; i++) {
                if(EventObjects[i].eventName == eventName) {
                    find = true;
                    break;
                }
            }
            if (find) {
                if (!ConditionCheck())
                    return;
                if (NumberOfOperator == NumberOfTrigger.ONCE && StartOnce)
                    return;
                StartOnce = true;
                StartAction();
            }
        }
        bool ConditionCheck() {
            if (Condition.Count > 0) {
                switch (ActionLogicalOperators) {
                    case LogicalOperators.AND:
                        for (int i = 0; i < Condition.Count; i++) {
                            if (Condition[i].IfTrue == false)
                                return false;
                        }
                        return true;

                    case LogicalOperators.OR:
                        for (int i = 0; i < Condition.Count; i++) {
                            if (Condition[i].IfTrue == true)
                                return true;
                        }
                        return false;
                }
            }
            return true;
        }

        void StartAction() {
            switch (EndType) {
                case TriggerEndType.FINISH_AND_DIE:
                    GameObject GO = new GameObject("Trigger Action");
                    GO.transform.parent = transform;
                    TriggerActionInvoker triggerAction = GO.AddComponent<TriggerActionInvoker>();
                    triggerAction.StartAction(Sequence, false, TriggerActionCicleEnd);
                    break;
                case TriggerEndType.FINISH_AND_RESTART:
                    GameObject GO2 = new GameObject("Trigger Action");
                    GO2.transform.parent = transform;
                    TriggerActionInvoker triggerAction2 = GO2.AddComponent<TriggerActionInvoker>();
                    triggerAction2.StartAction(Sequence, true, TriggerActionCicleEnd);
                    break;
            }
        }

        public void AddTriggerEvent(TriggerEvent triggerEvent) {
            EventObjects.Add(triggerEvent);
        }
       
    }
}
