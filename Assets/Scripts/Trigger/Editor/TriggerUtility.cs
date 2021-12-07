using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using Triggers;
public static class TriggerUtility {
    public static List<TriggerDirectory> FindDirectory() {
        List<TriggerDirectory> TriggerDirectorys = new List<TriggerDirectory>();
        string Path = Application.dataPath + '/' + "Trigger";
        if (Directory.Exists(Path)) {
            string[] folderPath = Directory.GetDirectories(Path);
            foreach (string directoryPath in folderPath) {
                string folderName = new DirectoryInfo(directoryPath).Name;
                TriggerDirectorys.Add(new TriggerDirectory(folderName));
            }
        }
        return TriggerDirectorys;
    }
    public static List<TriggerDirectory> GetTriggerDirectorys() {
        List<TriggerDirectory> TriggerDirectorys = FindDirectory();
        for (int i = 0; i < TriggerDirectorys.Count; i++) {
            string Path = "Assets" + '/' + "Trigger" + '/' + TriggerDirectorys[i].DirectoryName;
            if (Directory.Exists(Path)) {
                DirectoryInfo di = new DirectoryInfo(Path);
                FileInfo[] files = di.GetFiles("*.asset");
                string[] triggerNames = new string[files.Length];

                for (int j = 0; j < files.Length; j++) {
                    triggerNames[j] = files[j].Name;
                }
                for (int k = 0; k < triggerNames.Length; k++) {
                    //Debug.Log(triggerNames[k]);
                    string assetPath = Path + "/" + triggerNames[k];
                    TriggerAction triggerOb = (TriggerAction)AssetDatabase.LoadAssetAtPath(assetPath, typeof(TriggerAction));
                    TriggerDirectorys[i].AddTrigger(triggerOb);
                    if (triggerOb == null)
                        Debug.Log("트리거 없다");
                }
            }
            else
                Debug.LogWarning("해당 경로는 없다 : " + Path);
        }
        return TriggerDirectorys;
    }
}
