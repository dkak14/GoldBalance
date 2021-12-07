using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossObject : MonoBehaviour
{
    EnemyController spriteRenderer;
    void Start()
    {
        TryGetComponent(out spriteRenderer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
