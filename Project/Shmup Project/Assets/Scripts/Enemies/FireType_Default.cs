using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This is a default fire type.
/// </summary>
public class FireType_Default : EnemyFires
{
    protected override void FireMissiles()
    {
        Vector3 firePosition = 
            transform.position + 0.5f * transform.up;

        GameObject.Instantiate(
            missile,
            firePosition,
            transform.rotation);
    }
}
