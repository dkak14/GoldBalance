using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SpiderWeb : MonoBehaviour
{
    [SerializeField] float destroyDuration;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigidbody2d;
    float speed;
    EnemyController attacker;
    private void Awake() {
        TryGetComponent(out rigidbody2d);
        TryGetComponent(out spriteRenderer);
        StartCoroutine(C_Destroy());
    }
    IEnumerator C_Destroy() {
        yield return new WaitForSeconds(destroyDuration);
        spriteRenderer.DOColor(new Color(1, 1, 1, 0), 0.5f).OnComplete(() => { Destroy(gameObject); });
    }
    public void BulletSetting(EnemyController attacker, float speed, Vector2 dir) {
        this.attacker = attacker;
        this.speed = speed;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rigidbody2d.AddForce(dir * speed, ForceMode2D.Impulse);
    }
    protected virtual void CollisionPlatform() {
        Destroy(gameObject);
    }
    protected virtual void CollisionUnit(UnitControllerBase unit) {
        unit.Damaged(attacker.damage, attacker, WeaponType.NULL);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform")) {
            CollisionPlatform();
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player")) {
            UnitControllerBase unit;
            if (collision.TryGetComponent(out unit)) {
                CollisionUnit(unit);
            }
        }
    }
}
