using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MyGizmos {
    public static void DrawWireCicle(Vector2 center, float radius, int smoothNum) {
        float angle = (float)360 / smoothNum;
        Vector2[] dir = new Vector2[smoothNum];
        dir[0] = center + new Vector2(Mathf.Cos(0), Mathf.Sin(0)) * radius;
        for (int i = 1; i < smoothNum; i++) {
            float dirAngle = angle * i;
            dirAngle *= Mathf.Deg2Rad;
            Vector2 dirvec = new Vector2(Mathf.Cos(dirAngle), Mathf.Sin(dirAngle)) * radius;
            dir[i] = center + dirvec;
            Gizmos.DrawLine(dir[i - 1], dir[i]);
        }
        Gizmos.DrawLine(dir[smoothNum - 1], dir[0]);
    }
}
