using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agents
{
    [SerializeField]
    protected Transform target;

    protected override void CalcSteeringForce()
    {
        if (target == null)
        {
            return;
        }

        //Desired velocity is max speed towards the target.
        Vector3 desiredVelocity =
            (target.position - transform.position).normalized *
            movementManager.MaxSpeed;

        Vector3 currentVelocity = movementManager.Velocity;

        //Force is max force to turn to desired velocity.
        Vector3 force = 
            (desiredVelocity - currentVelocity).normalized * 
            movementManager.MaxForce;

        movementManager.ApplyForce(force);
    }
}
