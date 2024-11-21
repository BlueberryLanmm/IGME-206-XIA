using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agents : MonoBehaviour
{
    protected PhysicsObject movementManager;

    private void Awake()
    {
        movementManager = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    protected void Update()
    {
        CalcSteeringForce();
    }

    protected abstract void CalcSteeringForce();
}
