using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerWeaponController : MonoBehaviour, IInitialization
{
    PlayerInputController playerInputController;
    public void Awake() {
        Initialization();
    }
    public void Initialization() {
        TryGetComponent(out playerInputController);
    }
}
