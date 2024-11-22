using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agents : MonoBehaviour
{
    protected PhysicsObject movementManager;

    private void Awake()
    {
        //Make reference to the PhysicsObject script.
        movementManager = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        CalcSteeringForce();
    }

    protected abstract void CalcSteeringForce();
}
