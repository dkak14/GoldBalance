using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EquipWeaponUIController : MonoBehaviour
{
    [SerializeField]List<EquipWeaponUI> list;
    private void Awake() {
        EventManager.Instance.GetWeapon += GetWeapon;
        EventManager.Instance.ThrowWeapon += ThrowWeapon;
        EventManager.Instance.SelectWeapon += SelectWeapon;
        for (int i = 0; i < list.Count; i++) {
            list[i].Init();
            list[i].GetWeapon(null);
        }
        list[0].IsSelect = true;
    }
    private void OnDestroy() {
        EventManager.Instance.GetWeapon -= GetWeapon;
        EventManager.Instance.ThrowWeapon -= ThrowWeapon;
        EventManager.Instance.SelectWeapon -= SelectWeapon;
    }

    void GetWeapon(int index, PickUpObject weapon) {
        list[index].GetWeapon(weapon);
    }
    void ThrowWeapon(int index, PickUpObject weapon) {
        list[index].GetWeapon(null);
    }
    void SelectWeapon(int index, PickUpObject weapon) {
        for(int i = 0; i< list.Count; i++) {
            if (i != index)
                list[i].IsSelect = false;
        }
        list[index].IsSelect = true;
    }
}
