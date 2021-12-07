using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerHPUI : MonoBehaviour
{
    [SerializeField] float barSpeed;
    [SerializeField] Image hpBar;
    [SerializeField] Image backHpBar;
    [SerializeField] TextMeshProUGUI hpText;
    UnitControllerBase player;

    Coroutine hpBarRoutine;
    private void Start() {
        player = UnitManager.Instance.GetUnit("Player");
        if (player != null) {
            player.hpValueChange += UIUpdate;
            hpText.text = player.HP + "/" + player.MaxHP;
        }
    }
    void UIUpdate(int hp) {
        hpText.text = player.HP + "/" + player.MaxHP;

        if (hpBarRoutine == null) {
            hpBarRoutine = StartCoroutine(C_HPBar());
        }
    }
    IEnumerator C_HPBar() {
        float value = (float)(player.HP) / player.MaxHP;
        hpBar.fillAmount = value;

        float lastTime = 1;
        while(lastTime > 0) {
            value = (float)(player.HP) / player.MaxHP;
            hpBar.fillAmount = value;
            lastTime -= Time.deltaTime;
            yield return null;
        }

        while (backHpBar.fillAmount > value) {
            value = (float)(player.HP) / player.MaxHP;
            hpBar.fillAmount = value;
            backHpBar.fillAmount -= Time.deltaTime * barSpeed;
            yield return null;
            
        }
        backHpBar.fillAmount = value;
        hpBarRoutine = null;
    }
}
