using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Weapon
{
    protected override void Aim(Vector2 centerOffset, Vector2 dir, float dst, PlayerAnimClipSpriteData spriteData) {
        base.Aim(centerOffset, dir, dst, spriteData);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (dir.x < 0) {
            spriteRenderer.flipY = true;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
        else {
            spriteRenderer.flipY = false;
            transform.eulerAngles = new Vector3(0, 0, angle);
        }
    }
}
