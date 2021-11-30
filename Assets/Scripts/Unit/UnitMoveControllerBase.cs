using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMoveControllerBase : MonoBehaviour, IInitialization
{
    public float Speed { get { return unitController.Speed; } }
    public float jumpPower;
    protected UnitControllerBase unitController;
    protected Rigidbody2D rigidbody2d;
    protected Collider2D collider2d;

    public bool isMove = true;
    public bool isJump = true;
    protected virtual void Awake() {
        Initialization();
    }
    public virtual void Initialization() {
        TryGetComponent(out unitController);
        TryGetComponent(out rigidbody2d);
        TryGetComponent(out collider2d);
    }
    public bool Move(float axis) {
        if (!unitController.IsActiveState(UnitAnimState.Cinematic) && isMove) {
            MoveAction(axis, Speed, Speed);
            return true;
        }
        return false;
    }
    public void Move(Transform target) {
        float axis = target.position.x > transform.position.x ? 1 : -1;
        Move(axis);
    }
    public void DownPlatform() {
        if (unitController.onPlatform) {
            Collider2D effector;
            if(unitController.onPlatformHitCollider.transform.TryGetComponent(out effector)) {
                StartCoroutine(C_FallTimer(effector));
            }
        }
    }
    IEnumerator C_FallTimer(Collider2D effector) {
        Physics2D.IgnoreCollision(collider2d, effector);
        rigidbody2d.AddForce(Vector2.down, ForceMode2D.Impulse);
        yield return new WaitForSeconds(0.5f);
        Physics2D.IgnoreCollision(collider2d, effector, false);
    }
    protected virtual void MoveAction(float axis, float speed, float maxSpeed) {
        float xVelocity = rigidbody2d.velocity.x;
        float addSpeed;

        unitController.FlipX = axis > 0 ? false : true;
        if (axis < 0) {
            addSpeed = xVelocity > -speed ? -speed - xVelocity : 0;
            addSpeed = Mathf.Max(-speed, addSpeed);
        }
        else {
            addSpeed = xVelocity < speed ? speed - xVelocity : 0;
            addSpeed = Mathf.Min(speed, addSpeed);
        }
        rigidbody2d.AddForce(Vector2.right * addSpeed, ForceMode2D.Impulse);
    }
    public bool Jump(float power) {
        if (!unitController.IsActiveState(UnitAnimState.Cinematic) && isJump) {
            JumpAction(power);
            return true;
        }
        return false;
    }
    protected virtual void JumpAction(float power) {
        if(unitController.onPlatform)
        rigidbody2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
    }
    public virtual void DebugMove(float axis, float speed, float maxSpeed) {
        MoveAction(axis, speed, maxSpeed);
    }
}
