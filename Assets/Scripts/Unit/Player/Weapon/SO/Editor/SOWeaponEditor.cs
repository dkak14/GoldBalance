using System.Collections;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using UnityEngine;
using UnityEditor;
using UnityEngine.Networking;
using Unity.EditorCoroutines.Editor;
[CustomEditor(typeof(SOWeapon), true), CanEditMultipleObjects]
public class SOWeaponEditor : Editor
{
    readonly string URL = 
        "https://docs.google.com/spreadsheets/d/1bODkhVYnj8Rgi53SUSNJHVa1DdGwU4Zs/export?format=csv";
    SOWeapon soWeapon;
    private void OnEnable() {
        soWeapon = (SOWeapon)target;
    }
    public override void OnInspectorGUI() {
        if (GUILayout.Button("업데이트")) {
            //Thread thread = new Thread(new ThreadStart(GetData));
            //thread.Start();
            MyGetData();
           // EditorCoroutineUtility.StartCoroutine(DataUpdate(), this);
        }
        if(GUILayout.Button("무기 넣기")) {
            Dictionary<int, Weapon> weaponDic = new Dictionary<int, Weapon>();
            for(int i = 0; i< soWeapon.weaponObject.Count; i++) {
                int id = soWeapon.weaponObject[i].ID;
                Weapon weapon = soWeapon.weaponObject[i].weapon;
                if (!weaponDic.ContainsKey(id)) {
                    weaponDic.Add(id,weapon);
                }
                else {
                    Debug.LogWarning(id + "무기는 이미 있음");
                }
            }
            for (int i = 0; i < soWeapon.weaponData.Count; i++) {
                int id = soWeapon.weaponData[i].ID;
                Weapon weapon;
                if(weaponDic.TryGetValue(id, out weapon)) {
                    soWeapon.weaponData[i] = new WeaponData(weapon, soWeapon.weaponData[i]);
                }
            }
        }
        base.OnInspectorGUI();
    }
    IEnumerator DataUpdate() {
        Debug.Log("시트데이터 받아오는 중");
        UnityWebRequest www = UnityWebRequest.Get(URL);
        yield return www.SendWebRequest();
        string data = www.downloadHandler.text;
        Debug.Log(data);
        string[] row = data.Split('\n');
        soWeapon.weaponData = new List<WeaponData>();
        for (int i = 2; i < row.Length; i++) {
            string[] column = row[i].Split(',');
            string name = column[0];
            int id = int.Parse(column[1]);
            int damage = int.Parse(column[2]);
            WeaponType type = (WeaponType)Enum.Parse(typeof(WeaponType), column[3]);
            float reloading = float.Parse(column[4]);
            float attackSpeed = float.Parse(column[5]);
            int bulletFiringDelay = int.Parse(column[6]);
            soWeapon.weaponData.Add(new WeaponData(name, id, damage,reloading,attackSpeed,bulletFiringDelay, type));
        }
    }
    void MyGetData() {
        Thread thread = new Thread(new ThreadStart(DataThread));
        thread.Start();
    }
    void DataThread() {
        Debug.Log("시트 데이터 받아오는 중");
        string url = @"https://docs.google.com/spreadsheets/d/1bODkhVYnj8Rgi53SUSNJHVa1DdGwU4Zs/export?format=csv";
        WebClient wc = new WebClient();
        wc.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:22.0) Gecko/20100101 Firefox/22.0");
        wc.Headers.Add("DNT", "1");
        wc.Headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
        wc.Headers.Add("Accept-Encoding", "deflate");
        wc.Headers.Add("Accept-Language", "en-US,en;q=0.5");

        var data = wc.DownloadString(url);
        Debug.Log(data);
        string[] row = data.Split('\n');
        soWeapon.weaponData = new List<WeaponData>();
        for (int i = 2; i < row.Length; i++) {
            string[] column = row[i].Split(',');
            string name = column[0];
            int id = int.Parse(column[1]);
            int damage = int.Parse(column[2]);
            WeaponType type = (WeaponType)Enum.Parse(typeof(WeaponType), column[3]);
            float reloading = float.Parse(column[4]);
            float attackSpeed = float.Parse(column[5]);
            int bullet = int.Parse(column[6]);
            soWeapon.weaponData.Add(new WeaponData(name, id, damage, reloading, attackSpeed, bullet, type));

        }
    }
}
public class MyWebClient {
    string RequestLine;
    public string Header;
}
public class WebClientEx : WebClient {
    public WebClientEx(CookieContainer container) {
        this.container = container;
    }

    private readonly CookieContainer container = new CookieContainer();

    protected override WebRequest GetWebRequest(Uri address) {
        WebRequest r = base.GetWebRequest(address);
        var request = r as HttpWebRequest;
        if (request != null) {
            request.CookieContainer = container;
        }
        return r;
    }

    protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result) {
        WebResponse response = base.GetWebResponse(request, result);
        ReadCookies(response);
        return response;
    }

    protected override WebResponse GetWebResponse(WebRequest request) {
        WebResponse response = base.GetWebResponse(request);
        ReadCookies(response);
        return response;
    }

    private void ReadCookies(WebResponse r) {
        var response = r as HttpWebResponse;
        if (response != null) {
            CookieCollection cookies = response.Cookies;
            container.Add(cookies);
        }
    }
}