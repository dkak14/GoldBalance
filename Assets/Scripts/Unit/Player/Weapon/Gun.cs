using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Gun : Weapon
{
    [SerializeField] Bullet bullet;
    [SerializeField] int bulletSpeed;
    [SerializeField] Vector2 bulletOffSet;
    int lastBullet;
    [SerializeField] float reloadCul;
    float lastReload;
    bool reloading = false;
    float cul;

    EquipWeaponUI displayUI;
    protected override void Aim(Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        base.Aim(centerOffset, dir, dst, spriteData);
        if (dir.x < 0) {
            spriteRenderer.flipY = true;
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else {
            spriteRenderer.flipY = false;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (reloading) {
            lastReload -= Time.deltaTime;
            if (lastReload <= 0) {
                reloading = false;
                lastBullet = weaponData.bullet;
                Debug.Log("재장전 완료");
                DisplayUI(displayUI);
            }
        }
    }
    protected override bool AttackCondition() {
        return reloading ? false : true && lastBullet > 0;
    }
    protected override void Attack(Vector2 dir) {
        lastBullet--;
        Vector2 offSet = spriteRenderer.flipY ? new Vector2(-bulletOffSet.x, bulletOffSet.y) : bulletOffSet;
        Bullet spawnBullet = Instantiate(bullet, (Vector2)transform.position + offSet, Quaternion.identity);
        Vector2 bulletDir = spriteRenderer.flipY ? -Vector2.right : Vector2.right;
        spawnBullet.BulletSetting(weaponData.damage, bulletSpeed, bulletDir);
        DisplayUI(displayUI);
        if (lastBullet <= 0) {
            lastReload = reloadCul;
            Debug.Log("재장전 중 " +lastReload);
            reloading = true;
        }
        if(!unitAnimator.GetBool("isMove"))
        unitAnimator.SetTrigger("Attack");
    }

    public override void PickUp(PlayerPickUpController pickUpController, Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        base.PickUp(pickUpController, centerOffset, dir, dst, spriteData);
        if (reloading) {
            lastReload = reloadCul;
        }
    }
    public override void NotSelectPickUp(PlayerPickUpController pickUpController) {
        base.NotSelectPickUp(pickUpController);
        if (reloading) {
            lastReload = reloadCul;
        }
    }
    public override void Initialization() {
        base.Initialization();
        lastBullet = weaponData.bullet;
    }
    public override void DisplayUI(EquipWeaponUI ui) {
        displayUI = ui;
        StringBuilder builder = new StringBuilder();
        builder.Append(lastBullet);
        builder.Append("/");
        builder.Append(weaponData.bullet);
        ui.cornerText.text = builder.ToString();
    }
    private void OnDrawGizmos() {
        if (spriteRenderer) {
            Vector2 offSet = spriteRenderer.flipY ? new Vector2(-bulletOffSet.x, bulletOffSet.y) : bulletOffSet;
            Debug.Log(offSet);
            MyGizmos.DrawWireCicle((Vector2)transform.position + offSet, 0.1f, 30);
        }
        else {
            MyGizmos.DrawWireCicle((Vector2)transform.position + bulletOffSet, 0.1f, 30);
        }
    }
}
