using System;
using System.Collections;
using UnityEngine;
namespace Triggers {
    [CreateAssetMenu(fileName = "DebugUnitDie", menuName = "Trigger/Gold/DebugUnitDie", order = 1)]
    public class AcDebugUnitDie : TriggerAction {
        [SerializeField] UnitControllerBase unitController;
        public override bool Action() {
            if (unitController != null)
                unitController.Die();
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcDebugUnitDie copy = CreateInstance<AcDebugUnitDie>();
            copy.unitController = unitController;
            return copy;
        }
    }
}