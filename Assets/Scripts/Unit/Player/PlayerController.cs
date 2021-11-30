using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : UnitControllerBase
{
    PlayerAnimController animController;
    Animator animator;
    protected override void die() {
        animController.AnimType = WeaponType.NULL;
        animator.SetBool("isDie", true);
    }
    public override void Initialization() {
        base.Initialization();
        TryGetComponent(out animController);
        TryGetComponent(out animator);
    }
}
