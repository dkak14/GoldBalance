using UnityEngine;
namespace Triggers {
    [CreateAssetMenu(fileName = "SetActiveScreenEffect", menuName = "Trigger/Gold/SetActiveScreenEffect", order = 1)]
    public class AcSetActiveScreenEffect : TriggerAction {
        [SerializeField] bool startOrEnd;
        [SerializeField] string effectName;
        [SerializeField] float duration = 0;
        [SerializeField] float value = 0;
        public override bool Action() {
            ScreenManager.Instance.SetActiveScreenEffect(effectName, duration, value, startOrEnd);
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcSetActiveScreenEffect setActiveScreenEffect = CreateInstance<AcSetActiveScreenEffect>();
            setActiveScreenEffect.startOrEnd = startOrEnd;
            setActiveScreenEffect.effectName = effectName;
            setActiveScreenEffect.duration = duration;
            setActiveScreenEffect.value = value;
            return setActiveScreenEffect;
        }
    }
}
