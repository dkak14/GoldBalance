using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : Singleton<EventManager>
{
    public Action<bool> SetActiveCutScene = delegate { };
    public Action<int, PickUpObject> GetWeapon = delegate { };
    public Action<int, PickUpObject> ThrowWeapon = delegate { };
    public Action<int, PickUpObject> SelectWeapon = delegate { };
    public Action<UnitControllerBase> SpawnUnit = delegate { };
    public Action<UnitControllerBase, int> DieUnit = delegate { };
    public Action<string> TriggerEventMessage = delegate { };

    public Action<string> SceneChangeStart = delegate { };
    public Action SceneChangeEnd = delegate { };
}
