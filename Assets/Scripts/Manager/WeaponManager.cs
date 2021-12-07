using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : SingletonBehaviour<WeaponManager>
{
    [SerializeField] SOWeapon soWeapon;
    Dictionary<int, WeaponData> weaponDic = new Dictionary<int, WeaponData>();
    public override void Awake() {
        List<WeaponData> weaponList = soWeapon.weaponData;
        for(int i = 0;i < weaponList.Count; i++) {
            weaponDic.Add(weaponList[i].ID, weaponList[i]);
        }
    }
    public Weapon GetWeapon(int id) {
        WeaponData weaponData;
        if (weaponDic.TryGetValue(id, out weaponData)) {
            Weapon weapon = weaponData.weapon;
            weapon.weaponData = weaponData;
        }
        return weaponData.weapon;
    }
}
