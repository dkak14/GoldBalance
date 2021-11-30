using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "SpawnEffect", menuName = "Trigger/Gold/SpawnEffect", order = 1)]
    public class AcSpawnEffect : TriggerAction {
        [SerializeField] public SOEffectObject effectObject;
        [SerializeField] string id;
        [SerializeField] float scale;
        [SerializeField] Vector3 spawnPos;
        public override bool Action() {
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcSpawnEffect copy = CreateInstance<AcSpawnEffect>();
            copy.effectObject = effectObject;
            copy.id = id;
            copy.scale = scale;
            copy.spawnPos = spawnPos;
            return copy;
        }
    }
}
