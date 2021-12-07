using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Google.Apis.Sheets.v4;
//using Google.Apis.Sheets.v4.Data;
//using Google.Apis.Services;
using System;
[CreateAssetMenu(fileName = "WeaponData", menuName = "SO/WeaponData", order = 1)]
public class SOWeapon : ScriptableObject
{
    public List<WeaponData> weaponData = new List<WeaponData>();
    public List<WeaponObject> weaponObject = new List<WeaponObject>();
    public void SetWeapon(int index, Weapon weapon) {
        try {
            weaponData[index] = new WeaponData(weapon , weaponData[index]);
        }
        catch(Exception e) {
            Debug.LogWarning(e);
        }
    }
    // public void GetData() {
    //     //UserCredential credential;

    //     //using (var stream =
    //     //    new FileStream("client_secret.json", FileMode.Open, FileAccess.Read)) {
    //     //    string credPath = System.Environment.GetFolderPath(
    //     //        System.Environment.SpecialFolder.Personal);
    //     //    credPath = Path.Combine(credPath, ".credentials/sheets.googleapis.com-dotnet-quickstart.json");

    //     //    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
    //     //        GoogleClientSecrets.Load(stream).Secrets,
    //     //        Scopes,
    //     //        "user",
    //     //        CancellationToken.None,
    //     //        new FileDataStore(credPath, true)).Result;
    //     //    // Console.WriteLine("Credential file saved to: " + credPath);
    //     //}

    //     //// Create Google Sheets API service.
    //     var service = new SheetsService(new BaseClientService.Initializer());
    //     //    HttpClientInitializer = credential,
    //     //    ApplicationName = ApplicationName,
    //     //});
    //     //1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms ���� ����
    //     //
    //     // Define request parameters.
    //     String spreadsheetId = "1bODkhVYnj8Rgi53SUSNJHVa1DdGwU4Zs";// 1) d/ ~~/edit ������ ID �� ����
    //     String range = "������ ���� ��Ʈ1!A3:F";// 2)���� ����   "��Ʈ��!����"  A2:F ������;
    //     SpreadsheetsResource.ValuesResource.GetRequest request =
    //             service.Spreadsheets.Values.Get(spreadsheetId, range);

    //     // Prints the names and majors of students in a sample spreadsheet:
    //     // https://docs.google.com/spreadsheets/d/1BxiMVs0XRA5nFMdKvBdBZjgmUUqptlbs74OgvE2upms/edit
    //     ValueRange response = request.Execute();
    //     IList<IList<System.Object>> values = response.Values;
    //     //values != null &&
    //     if (values != null && values.Count > 0)//0�̻��̰ų� null
    //     {
    //         Console.WriteLine("������ ����");

    //         foreach (var row in values) {
    //             // Print columns A and E, which correspond to indices 0 and 4.
    //             Console.WriteLine("{0}, {1} , {2} , {3} , {4} , {5}", row[0], row[1], row[2], row[3], row[4], row[5]);
    //         }

    //     }
    //     else {
    //         Console.WriteLine("No data found.");
    //     }
    //     //  Console.Read();
    // }
    [Serializable]
    public struct WeaponObject {
        public Weapon weapon;
        public int ID;
    }
}
[System.Serializable]
public struct WeaponData {
    public Weapon weapon;
    public string name;
    public int ID;
    public int damage;
    public float reloading;
    public float attackSpeed;
    public int bullet;
    public WeaponType type;

    public WeaponData(string name, int iD, int damage, 
        float reloading, float attackSpeed, int bullet, WeaponType type) {
        this.weapon = null;
        this.name = name;
        ID = iD;
        this.damage = damage;
        this.reloading = reloading;
        this.attackSpeed = attackSpeed;
        this.bullet = bullet;
        this.type = type;
    }
    public WeaponData(Weapon weapon, WeaponData weaponData) {
        this.weapon = weapon;
        this.name = weaponData.name;
        ID = weaponData.ID;
        this.damage = weaponData.damage;
        this.reloading = weaponData.reloading;
        this.attackSpeed = weaponData.attackSpeed;
        this.bullet= weaponData.bullet;
        this.type = weaponData.type;
    }
}
public enum WeaponType {
    NULL,SHORT_GUN,LONG_GUN,MELEE, BAT
}