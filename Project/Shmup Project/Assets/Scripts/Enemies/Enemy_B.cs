using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Enemy_B : EnemyController
{
    [SerializeField]
    private float missileAngle;
    [SerializeField]
    private float missileNumber;

    private float fireTimer;
    private float angleInterval;



    private void Start()
    {
        base.Start();

        fireTimer = fireCooldown;
        angleInterval = missileAngle / (missileNumber - 1);
    }

    protected override void FireMissiles()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer < 0f)
        {
            fireTimer = fireCooldown;

            for(int i = 0; i < missileNumber; i++)
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
                    transform.position + direction,
                    transform.rotation);

                newMissile.transform.up = direction;
            }
        }
    }
}
