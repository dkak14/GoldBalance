using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : PickUpObject
{
    [SerializeField]protected float attackCul;
    public WeaponData weaponData;
    protected float culTimeValue { get { return Mathf.InverseLerp(0, weaponData.attackSpeed, attackCul); } }
    public override void PickUp(PlayerPickUpController pickUpController, Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        base.PickUp(pickUpController, centerOffset, dir, dst, spriteData);
        if(attackCul > 0) {
            StartCoroutine(C_Attack());
        }
    }
    public override bool Action(Vector2 dir) {
        if (attackCul <= 0 && AttackCondition()) {
            Attack(dir);
            StartCoroutine(C_Attack());
            return true;
        }
        return false;
    }
    protected virtual void Attack(Vector2 dir) { }
    
    protected virtual bool AttackCondition() {
        return true;
    }
    IEnumerator C_Attack() {
        attackCul = weaponData.attackSpeed;
        while (attackCul > 0) {
            attackCul -= Time.deltaTime;
            yield return null;
        }
        attackCul = 0;
    }
}
[System.Serializable]
public struct WeaponEffect {
    public SpriteRenderer effectObject;
    public string clipName;
    public int index;
    public WeaponEffectPos falseFlipX;
    public WeaponEffectPos trueFlipX;
}
[System.Serializable]
public struct WeaponEffectPos {
    public Vector2 offset;
    public bool flip;
    public float angle;
}