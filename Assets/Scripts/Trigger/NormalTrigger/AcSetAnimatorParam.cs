using UnityEngine;
using UnityEditor;
namespace Triggers {
    [System.Serializable, CreateAssetMenu(fileName = "SetAnimatorParam", menuName = "Trigger/SetAnimatorParam", order = 1)]
    public class AcSetAnimatorParam : TriggerAction {
        [SerializeField] AnimatorParamType paramType;
        [SerializeField] Animator animator;
        [SerializeField] string paramName;
        [SerializeField] int intParam;
        [SerializeField] float floatParam;
        [SerializeField] bool boolParam;
        public override bool Action() {
            if(animator == null) {
                Debug.LogWarning("애니메이터가 없습니다");
                return true;
            }

            switch (paramType) {
                case AnimatorParamType.Int:
                    animator.SetInteger(paramName, intParam);
                    break;
                case AnimatorParamType.Float:
                    animator.SetFloat(paramName, floatParam);
                    break;
                case AnimatorParamType.Bool:
                    animator.SetBool(paramName, boolParam);
                    break;
                case AnimatorParamType.Trigger:
                    animator.SetTrigger(paramName);
                    break;
            }
            return true;
        }
        public override TriggerAction GetCopyTrigger() {
            AcSetAnimatorParam setAnimatorParam = CreateInstance<AcSetAnimatorParam>();
            setAnimatorParam.paramType = paramType;
            setAnimatorParam.animator = animator;
            setAnimatorParam.paramName = paramName;
            setAnimatorParam.intParam = intParam;
            setAnimatorParam.floatParam = floatParam;
            setAnimatorParam.boolParam = boolParam;
            return setAnimatorParam;
        }
        public enum AnimatorParamType {
            Int, Float, Bool, Trigger
        }
    }
}
