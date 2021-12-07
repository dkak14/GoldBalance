using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "SO/StageData", order = 1)]
public class SOStageData : ScriptableObject
{
    public List<StageData> stageDatas = new List<StageData>();
}
[System.Serializable]
public struct StageData {
    public string sceneName;
    public bool isJoin;
}
