using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hpText;
    UnitControllerBase player;
    private void Start() {
        player = UnitManager.Instance.GetUnit("Player");
        if (player != null) {
            player.hpValueChange += UIUpdate;
            hpText.text = "HP : " + player.HP;
        }
    }
    void UIUpdate(int hp) {
        hpText.text = "HP : " + player.HP;
    }
}
