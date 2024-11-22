using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agents
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float caughtRange;

    private void FixedUpdate()
    {
        base.FixedUpdate();

        OnCaught();
    }

    protected override void CalcSteeringForce()
    {
        if (target == null)
        {
            return;
        }

        //Desired velocity is max speed away from the target.
        Vector3 desiredVelocity =
            -(target.position - transform.position).normalized *
            movementManager.MaxSpeed;

        Vector3 currentVelocity = movementManager.Velocity;

        //Force is max force to turn to desired velocity.
        Vector3 force =
            (desiredVelocity - currentVelocity).normalized *
            movementManager.MaxForce;

        movementManager.ApplyForce(force);
    }

    /// <summary>
    /// Respawn the fleer when it gets caught.
    /// </summary>
    private void OnCaught()
    {
        if (Vector3.Distance(transform.position, target.position) < caughtRange)
        {
            movementManager.RandomSpawn();
        }
    }
}
