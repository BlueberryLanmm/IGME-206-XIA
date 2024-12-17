using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireType_A : EnemyFires
{
    protected override void FireMissiles()
    {
        Vector3 firePosition = 
            transform.position + 
            transform.up * enemyBoxRenderer.bounds.extents.y;

        GameObject.Instantiate(
            missile,
            firePosition,
            transform.rotation);
    }
}
