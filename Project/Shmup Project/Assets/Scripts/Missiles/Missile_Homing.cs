using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Homing : MissileController
{
    [SerializeField]
    private float effectRange;
    [SerializeField]
    private float turningForce;
    [SerializeField]
    private float maxTurningAngle;


    private void Update()
    {
        base.Update();

        Transform homingTarget;

        if ((homingTarget = HomingTarget()) != null)
        {
            UpdateDrivingForce(SeekForce(homingTarget.position));
        }
    }


    private Transform HomingTarget()
    {
        if (targets == null)
        {
            return null;
        }

        float minSqrDistance = Mathf.Infinity;
        Transform target = null;

        foreach (Transform t in targets)
        {
            if (!t.CompareTag("Player") &&
                !t.CompareTag("Enemy"))
            {
                continue;
            }

            float newSqrtDistance = Vector2.SqrMagnitude(t.position - transform.position);

            if (newSqrtDistance < minSqrDistance)
            {
                target = t;
                minSqrDistance = newSqrtDistance;
            }
        }

        return target;
    }


    private Vector2 SeekForce(Vector3 targetPos)
    {
        if (targetPos == null)
        {
            return Vector2.zero;
        }

        //Desired velocity is max speed towards the target.
        Vector2 desiredVelocity =
            (targetPos - transform.position).normalized *
            MaxSpeed;

        Vector2 currentVelocity = Velocity;

        float turningAngle = Vector2.SignedAngle(desiredVelocity, currentVelocity);

        if (turningAngle > maxTurningAngle)
        {
            Vector2 newDesiredVelocity = Vector2.zero;

            newDesiredVelocity.x = 
                Direction.x * MaxSpeed * Mathf.Cos(turningAngle * Mathf.Deg2Rad) + 
                Direction.y * MaxSpeed * Mathf.Sign(turningAngle * Mathf.Deg2Rad);

            newDesiredVelocity.y = 
                Direction.x * MaxSpeed * Mathf.Sin(-turningAngle * Mathf.Deg2Rad) +
                Direction.y * MaxSpeed * Mathf.Cos(-turningAngle * Mathf.Deg2Rad);
        }

        //Force is max force to turn to desired velocity.
        Vector2 force =
            (desiredVelocity - currentVelocity).normalized *
            turningForce;

        return force;
    }
}
