using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_A : EnemyController
{
    private float fireTimer;


    private void Start()
    {
        base.Start();

        fireTimer = fireCooldown;
    }

    protected override void FireMissiles()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer < 0f)
        {
            fireTimer = fireCooldown;

            GameObject.Instantiate(
                missile,
                transform.position + transform.up,
                transform.rotation);
        }
    }
}
