using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

/// <summary>
/// This is a scatter fire type, will fire multiple missiles.
/// </summary>
public class FireType_Scatter : EnemyFires
{
    [SerializeField]
    private float missileAngle;
    [SerializeField]
    private float missileNumber;

    private float angleInterval;


    protected override void Start()
    {
        base.Start();
        angleInterval = missileAngle / (missileNumber - 1);
    }

    protected override void FireMissiles()
    {
        //Calculate fire direction for each missile.
        for (int i = 0; i < missileNumber; i++)
        {
            float fireAngle = ((1 - missileNumber) / 2 + i) * angleInterval;

            Vector3 direction = Vector3.zero;

            direction.x =
                transform.up.x * Mathf.Cos(fireAngle * Mathf.Deg2Rad) +
                transform.up.y * Mathf.Sin(fireAngle * Mathf.Deg2Rad);

            direction.y =
                transform.up.x * Mathf.Sin(-fireAngle * Mathf.Deg2Rad) +
                transform.up.y * Mathf.Cos(-fireAngle * Mathf.Deg2Rad);

            GameObject newMissile =
                GameObject.Instantiate(
                missile,
                transform.position + 0.5f * direction,
                transform.rotation);

            newMissile.transform.up = direction;
        }
    }
}
