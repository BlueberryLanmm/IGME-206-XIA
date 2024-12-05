using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : Agents
{
    [SerializeField]
    private float lookAheadTime;
    [SerializeField]
    private float wanderRadius;
    [SerializeField]
    private float wanderAngle;

    private float currentWanderAngle = 0;

    protected override Vector3 CalcSteeringForce()
    {
        Vector3 force = StayInBoundsForce(lookAheadTime);

        force += WanderForce(ref currentWanderAngle, wanderAngle, 
           3 * wanderAngle, lookAheadTime, wanderRadius);

        return force;
    }
}
