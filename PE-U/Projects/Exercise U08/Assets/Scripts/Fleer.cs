using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agents
{
    [SerializeField]
    protected Transform target;

    private void Update()
    {
        base.Update();


    }

    protected override void CalcSteeringForce()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredVelocity =
            -(target.position - transform.position).normalized *
            movementManager.MaxSpeed;

        Vector3 currentVelocity = movementManager.Velocity;

        Vector3 force =
            (desiredVelocity - currentVelocity).normalized *
            movementManager.MaxForce;

        movementManager.ApplyForce(force);
    }
}
