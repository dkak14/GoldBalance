using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    [SerializeField] int weaponID;
    void Start() {
        Weapon weapon = WeaponManager.Instance.GetWeapon(weaponID);
        if (weapon) {
            Instantiate(weapon, transform.position, Quaternion.identity);
        }
    }
}
