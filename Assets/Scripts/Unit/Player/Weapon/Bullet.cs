using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] string collisionUnit;
    UnitControllerBase attacker;
    Weapon weapon;
    float speed;
    private void Awake() {
        TryGetComponent(out rigidbody2d);
        Destroy(gameObject, 10);
    }
    public void BulletSetting(UnitControllerBase attacker, Weapon weapon, float speed, Vector2 dir) {
        this.attacker = attacker;
        this.weapon = weapon;
        this.speed = speed;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rigidbody2d.AddForce(dir * speed, ForceMode2D.Impulse);
    }
    protected virtual void CollisionPlatform() {
        Destroy(gameObject);
    }
    protected virtual void CollisionUnit(UnitControllerBase unit) {
        unit.Damaged(weapon.weaponData.damage, attacker, weapon.weaponData.type);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Platform")) {
            CollisionPlatform();
        }
        if(collision.gameObject.layer == LayerMask.NameToLayer(collisionUnit)) {
            UnitControllerBase unit;
            if (collision.TryGetComponent(out unit)) {
                CollisionUnit(unit);
            }
        }
    }
}
