using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogData", menuName = "SO/DialogData", order = 1)]
public class SODialogData : ScriptableObject
{
    public List<DialogData> dialogData = new List<DialogData>();
    public List<CharacterData> characterDatas = new List<CharacterData>();
    [SerializeField] Dictionary<int, DialogData> dialogDataDic;
    [SerializeField] Dictionary<int, CharacterData> characterDataDic;
    public void DataUpdate() {
        dialogDataDic = new Dictionary<int, DialogData>();
        for (int i = 0; i < dialogData.Count; i++) {
            if(!dialogDataDic.ContainsKey(dialogData[i].id))
            dialogDataDic.Add(dialogData[i].id, dialogData[i]);
        }
        characterDataDic = new Dictionary<int, CharacterData>();
        for (int i = 0; i < characterDatas.Count; i++) {
            if (!characterDataDic.ContainsKey(characterDatas[i].id))
                characterDataDic.Add(characterDatas[i].id, characterDatas[i]);
        }
    }
    public DialogData GetDialog(int id) {
        if (dialogDataDic == null) {
            DataUpdate();
        }
        DialogData data;
        dialogDataDic.TryGetValue(id, out data);
        return data;
    }
    public CharacterData GetCharacterData(int id) {
        if(characterDataDic == null) {
            DataUpdate();
        }
        CharacterData data;
        characterDataDic.TryGetValue(id, out data);
        return data;
    }
}
[System.Serializable]
public struct DialogData {
    public int id;
    public int characterID;
    public int imageID;
    public float remainingTime;
    public string dialog;
    public string typingStartEvent;
    public string typingEndEvent;

    public DialogData(int id, int characterID, int imageID, string dialog) {
        this.id = id;
        this.characterID = characterID;
        this.imageID = imageID;
        this.dialog = dialog;
        remainingTime = 0;
        typingStartEvent = "";
        typingEndEvent = "";
    }
}
[System.Serializable]
public struct CharacterData {
    public int id;
    public string name;
    public CharacterData(int id, string name) {
        this.id = id;
        this.name = name;
    }
}