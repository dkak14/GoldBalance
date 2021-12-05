using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using DG.Tweening;
public class Gun : Weapon
{
    [SerializeField] Vector2 bulletOffSet;
    [SerializeField] float bulletShaking;
    [SerializeField, Header("총알 색깔")] Color bulletColor;
    LineRenderer lineRenderer;
    int lastBullet;
    float lastReload;
    bool reloading = false;
    float cul;

    int layerMask;

    EquipWeaponUI displayUI;
    protected override void Awake() {
        base.Awake();
        TryGetComponent(out lineRenderer);
    }
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
        float angle = Random.Range(-bulletShaking, bulletShaking);
        float bulletdirAngle = spriteRenderer.flipY ? 180 : 0;
        bulletdirAngle += angle;
        bulletdirAngle *= Mathf.Deg2Rad;
        Vector2 bulletDir = new Vector2(Mathf.Cos(bulletdirAngle), Mathf.Sin(bulletdirAngle));
        RaycastHit2D hit = Physics2D.Raycast((Vector2)transform.position + offSet,bulletDir * 10, 10, layerMask);
        if (hit) {
            lineRenderer.SetPosition(0, (Vector2)transform.position + offSet);
            lineRenderer.SetPosition(1, hit.point);
            UnitControllerBase enemy;
            if(hit.transform.TryGetComponent(out enemy)) {
                Damage(enemy);
            }
        }
        else {
            lineRenderer.SetPosition(0, (Vector2)transform.position + offSet);
            lineRenderer.SetPosition(1, (Vector2)transform.position + offSet + bulletDir * 10);
        }
        lineRenderer.DOKill();
        lineRenderer.startColor = bulletColor;
        lineRenderer.endColor = bulletColor;
        Color lineStartColor = bulletColor;
        Color lineEndColor = bulletColor;
        Color2 startColor = new Color2(lineStartColor, lineEndColor);
        Color2 endColor = new Color2(new Color(lineStartColor.r, lineStartColor.g, lineStartColor.b, 0), new Color(lineEndColor.r, lineEndColor.g, lineEndColor.b, 0));
        lineRenderer.DOColor(startColor, endColor, 0.1f);
        DisplayUI(displayUI);
        if (lastBullet <= 0) {
            lastReload = weaponData.reloading;
            Debug.Log("재장전 중 " +lastReload);
            reloading = true;
        }
        if(!unitAnimator.GetBool("isMove"))
        unitAnimator.SetTrigger("Attack");
    }

    public override void PickUp(PlayerPickUpController pickUpController, Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        base.PickUp(pickUpController, centerOffset, dir, dst, spriteData);
        if (reloading) {
            lastReload = weaponData.reloading;
        }
    }
    public override void NotSelectPickUp(PlayerPickUpController pickUpController) {
        base.NotSelectPickUp(pickUpController);
        if (reloading) {
            lastReload = weaponData.reloading;
        }
    }
    public override void Initialization() {
        base.Initialization();
        lastBullet = weaponData.bullet;
        layerMask = (1 << LayerMask.NameToLayer("Enemy")) + (1 << LayerMask.NameToLayer("Platform"));
    }
    public override void DisplayUI(EquipWeaponUI ui) {
        displayUI = ui;
        ui.underBox.gameObject.SetActive(true);
        StringBuilder builder = new StringBuilder();
        builder.Append(lastBullet);
        builder.Append("/");
        builder.Append(weaponData.bullet);
        ui.cornerText.text = builder.ToString();
    }
    private void OnDrawGizmos() {
        if (spriteRenderer) {
            Vector2 offSet = spriteRenderer.flipY ? new Vector2(-bulletOffSet.x, bulletOffSet.y) : bulletOffSet;
            MyGizmos.DrawWireCicle((Vector2)transform.position + offSet, 0.03f, 30);
        }
        else {
            MyGizmos.DrawWireCicle((Vector2)transform.position + bulletOffSet, 0.03f, 30);
        }
    }
}
