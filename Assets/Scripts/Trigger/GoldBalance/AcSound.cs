using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "Sound", menuName = "Trigger/Gold/Sound", order = 1)]
    public class AcSound : TriggerAction {
        [SerializeField] SoundType type;
        [SerializeField] string soundID;
        public override bool Action() {
            if(type == SoundType.BGM)
            SoundManager.Instance.Play(SoundType.BGM, soundID, true);
            else {
                SoundManager.Instance.PlayOneShot(SoundType.SFX, soundID, 1);
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcSound copy = CreateInstance<AcSound>();
            copy.type = type;
            copy.soundID = soundID;
            return copy;
        }
    }
}
