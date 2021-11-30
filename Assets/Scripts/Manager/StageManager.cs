using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : SingletonBehaviour<StageManager>
{
    [SerializeField] SOStageData soStageData;

    Dictionary<string, StageData> stageDataDic;
    public override void Awake()
    {
        base.Awake();
        stageDataDic = new Dictionary<string, StageData>();
        for(int i = 0;i < soStageData.stageDatas.Count; i++) {
            stageDataDic.Add(soStageData.stageDatas[i].sceneName, soStageData.stageDatas[i]);
        }
    }

    public StageData GetStageData(string stageID) {
        if (stageDataDic.ContainsKey(stageID)) {
            return stageDataDic[stageID];
        }
        return new StageData();
    }
}
