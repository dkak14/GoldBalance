using System.Collections.Generic;
using UnityEngine;
using System;
namespace Triggers {
    [Serializable, CreateAssetMenu(fileName = "Delay", menuName = "Trigger/Delay", order = 1)]
    public class AcDelay : TriggerAction {
        [SerializeField] float DelayTime = 1;
        [SerializeField] float time = 0;
        public override bool Action() {
            time -= Time.deltaTime;
            if (time > 0) {
                return false;
            }
            else
                return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcDelay delay = CreateInstance<AcDelay>();
            delay.DelayTime = DelayTime;
            delay.time = DelayTime;
            return delay;
        }
    }
}