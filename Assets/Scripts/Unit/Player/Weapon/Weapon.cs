using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Weapon : PickUpObject
{
    [SerializeField]protected float attackCul;
    public WeaponData weaponData;
    protected float culTimeValue { get { return Mathf.InverseLerp(0, weaponData.attackSpeed, attackCul); } }

    Coroutine shakeRoutine;
    CinemachineBasicMultiChannelPerlin noise;
    bool shakeEnd;
    public override void PickUp(PlayerPickUpController pickUpController, Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        base.PickUp(pickUpController, centerOffset, dir, dst, spriteData);
        if(attackCul > 0) {
            StartCoroutine(C_Attack());
        }
        unitAnimController.AnimType = weaponData.type;
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
    public void Damage(UnitControllerBase damagedUnit) {
        if(damagedUnit.Damaged(weaponData.damage, unitController, weaponData.type)) {
            Camera mainCamera = Camera.main;
            CinemachineBrain brain = mainCamera.GetComponent<CinemachineBrain>();
            CinemachineVirtualCamera CVC = brain.ActiveVirtualCamera.VirtualCameraGameObject.GetComponent<CinemachineVirtualCamera>();
            noise = CVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            shakeRoutine = StartCoroutine(C_Shake(noise));
        }
    }
    IEnumerator C_Shake(CinemachineBasicMultiChannelPerlin noise) {
        shakeEnd = false;
        noise.m_AmplitudeGain = 5;
        noise.m_FrequencyGain = 5;
        Time.timeScale = 0.2f;
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1f;
        noise.m_AmplitudeGain = 0;
        noise.m_FrequencyGain = 0;
        shakeEnd = true;
    }
    private void OnDestroy() {
        if(shakeRoutine != null) {
            if (noise != null && !shakeEnd) {
                noise.m_AmplitudeGain = 0;
                noise.m_FrequencyGain = 0;
            }
        }
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