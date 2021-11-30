using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EquipWeaponUI : MonoBehaviour
{
    [SerializeField] Image backGround;
    [SerializeField] Image weaponImage;
    [SerializeField] public TextMeshProUGUI cornerText;
    PickUpObject pickupObject;
    bool isSelect;
    public bool IsSelect { get { return isSelect; } set { isSelect = value; ImageUpdate(); } }

    public void Init() {
        weaponImage.color = new Color(1, 1, 1, 0);
    }
    public void GetWeapon(PickUpObject weapon) {
        if (weapon != null) {
            SpriteRenderer spriteRenderer;
            weapon.TryGetComponent(out spriteRenderer);
            weaponImage.sprite = spriteRenderer.sprite;
            weaponImage.color = new Color(1, 1, 1, 1);
            pickupObject = weapon;
            cornerText.text = "";

            pickupObject.DisplayUI(this);
        }
        else {
            cornerText.text = "";
            pickupObject = null;
            weaponImage.color = new Color(1, 1, 1, 0);
        }
        ImageUpdate();
    }

    public void ImageUpdate() {
        if (isSelect) {
            transform.localScale = Vector2.one;
        }
        else {
            transform.localScale = Vector2.one * 0.75f;
        }
    }
}
