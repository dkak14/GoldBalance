using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SOScreenData", menuName ="SO/Screen", order = 1)]
public class SOScreenEffect : ScriptableObject
{
    public List<ScreenData> screenDataList = new List<ScreenData>();
    [System.Serializable]
    public struct ScreenData {
        public ScreenEffect effect;
        public string ID;
    }
}
