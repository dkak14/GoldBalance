using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundData", menuName = "SO/SoundData", order = 1)]
public class SOSoundData : ScriptableObject
{
    public List<SoundData> soundDataList;
}
[System.Serializable]
public struct SoundData {
    [SerializeField]SoundType type;
    public SoundType soundType => type;
    public List<SoundClipData> clipDataList;
}
[System.Serializable]
public struct SoundClipData {
    [SerializeField] string id;
    public string clipID => id;
    [SerializeField] AudioClip clip;
    public AudioClip audioClip => clip;
}