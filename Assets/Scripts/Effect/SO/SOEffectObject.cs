using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SOEffectObject", menuName = "SO/EffectObject", order = 0)]
public class SOEffectObject : ScriptableObject
{
    public Material previewMaterial;
    public List<EffectObjectData> effectObjectDataList = new List<EffectObjectData>();
    [System.Serializable]
    public struct EffectObjectData {
        public EffectObject effect;
        public string id;
    }
}
