using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleer : Agents
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float caughtRange;

    protected override Vector3 CalcSteeringForce()
    {
        if (target == null)
        {
            return Vector3.zero;
        }

        return FleeForce(target.position);
    }
}
