using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeker : Agents
{
    [SerializeField]
    protected Transform target;

    protected override Vector3 CalcSteeringForce()
    {
        if (target == null)
        {
            return Vector3.zero;
        }

        return SeekForce(target.position);
    }
}
