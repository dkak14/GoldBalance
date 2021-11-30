using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType {
    BGM,SFX
}
public class SoundManager : SingletonBehaviour<SoundManager>
{
    [SerializeField] SOSoundData soSoundData;
    Dictionary<SoundType, Dictionary<string, SoundClipData>> soundDataDIc;
    Dictionary<SoundType, AudioSource> audioSourceDIc;
    [SerializeField] string startBGM;
    public override void Awake() {
        base.Awake();
        audioSourceDIc = new Dictionary<SoundType, AudioSource>();
        soundDataDIc = new Dictionary<SoundType, Dictionary<string, SoundClipData>>();

        for (int k = 0; k < soSoundData.soundDataList.Count; k++) {
            SoundType type = soSoundData.soundDataList[k].soundType;
            GameObject audioObject = new GameObject("Audio");
            audioObject.transform.parent = transform;
            AudioSource audioSource = (AudioSource)audioObject.AddComponent(typeof(AudioSource));
            audioSourceDIc.Add(type, audioSource);
            soundDataDIc.Add(type, new Dictionary<string, SoundClipData>());
            Dictionary<string, SoundClipData> dic = soundDataDIc[type];
            for (int p = 0; p < soSoundData.soundDataList[k].clipDataList.Count; p++) {
                dic.Add(soSoundData.soundDataList[k].clipDataList[p].clipID, soSoundData.soundDataList[k].clipDataList[p]);
            }
        }


        Play(SoundType.BGM, startBGM, true);
    }
    public float GetVoulme(SoundType type) {
        return audioSourceDIc[type].volume;
    }
    public void SetVolume(SoundType type, float volume) {
        volume = Mathf.Clamp(volume, 0, 1);
        audioSourceDIc[type].volume = volume;
    }
    public void Play(SoundType type, string clipID, bool loop) {
        SoundClipData soundData;
        if (soundDataDIc[type].TryGetValue(clipID, out soundData)) {
            audioSourceDIc[type].loop = loop;
            audioSourceDIc[type].clip = soundData.audioClip;
            audioSourceDIc[type].Play();
        }
        else {
            Debug.LogWarning(clipID + "는 없다.");
        }
    }
    public void PlayOneShot(SoundType type, string clipID, float volumeScale = 1) {
        SoundClipData soundData;
        if (soundDataDIc[type].TryGetValue(clipID, out soundData)) {
            audioSourceDIc[type].PlayOneShot(soundData.audioClip, volumeScale);
        }
        else {
            Debug.LogWarning(clipID + "는 없다.");
        }
    }

}
