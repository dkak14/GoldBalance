using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "UnitData", menuName = "SO/UnitData", order = 1)]
public class SOUnitData : ScriptableObject
{
    public UnitData unitData;
}
[System.Serializable]
public struct UnitData {

}