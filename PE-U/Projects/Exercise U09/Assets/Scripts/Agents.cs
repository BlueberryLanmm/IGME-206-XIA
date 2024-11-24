using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agents : MonoBehaviour
{
    protected PhysicsObject movementManager;

    private Camera camera;
    private float camLeft;
    private float camRight;
    private float camTop;
    private float camButton;

    private void Awake()
    {
        camera = Camera.main;

        //Make reference to the PhysicsObject script.
        movementManager = GetComponent<PhysicsObject>();
    }

    private void Start()
    {
        //Initialize the camera bounds.
        camLeft = -camera.orthographicSize * camera.aspect;
        camRight = camera.orthographicSize * camera.aspect;
        camButton = -camera.orthographicSize;
        camTop = camera.orthographicSize;
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        //Apply the force to the physicsObject script
        //ignoring the max force limit.
        movementManager.ApplyForce(CalcSteeringForce(), false);
    }

    protected abstract Vector3 CalcSteeringForce();

    protected Vector3 SeekForce(Vector3 targetPos)
    {
        //Desired velocity is max speed towards the target.
        Vector3 desiredVelocity =
            (targetPos - transform.position).normalized *
            movementManager.MaxSpeed;

        Vector3 currentVelocity = movementManager.Velocity;

        //Force is max force to turn to desired velocity.
        Vector3 force =
            (desiredVelocity - currentVelocity).normalized *
            movementManager.MaxForce;

        return force;
    }

    protected Vector3 FleeForce(Vector3 targetPos)
    {
        //Desired velocity is max speed away from the target.
        Vector3 desiredVelocity =
            -(targetPos - transform.position).normalized *
            movementManager.MaxSpeed;

        Vector3 currentVelocity = movementManager.Velocity;

        //Force is max force to turn to desired velocity.
        Vector3 force =
            (desiredVelocity - currentVelocity).normalized *
            movementManager.MaxForce;

        return force;
    }

    protected Vector3 WanderForce(ref float currentWanderAngle, float wanderRange, 
        float maxWanderAngle, float time, float radius)
    {
        //Choose a distance ahead
        Vector3 futurePos = GetFuturePosition(time);

        //Get a random angle by adding on a bit to whatever we used last time!
        currentWanderAngle += Random.Range(-wanderRange, wanderRange);

        // And stay inside a given max range!
        if (currentWanderAngle > maxWanderAngle)
        {
            currentWanderAngle = maxWanderAngle;
        }
        else if (currentWanderAngle < -maxWanderAngle)
        {
            currentWanderAngle = -maxWanderAngle;
        }

        //Where would that displacement vector end?  Go there.
        Vector3 targetPos = futurePos;
        targetPos.x += Mathf.Cos(currentWanderAngle * Mathf.Deg2Rad) * radius;
        targetPos.y += Mathf.Sin(currentWanderAngle * Mathf.Deg2Rad) * radius;

        return SeekForce(targetPos);
    }

    private Vector3 GetFuturePosition(float time)
    {
        return movementManager.Velocity * time + movementManager.Position;
    }

    protected Vector3 StayInBoundsForce(float time)
    {
        //Choose a distance ahead
        Vector3 futurePos = GetFuturePosition(time);

        //Calculate how far the future position will gone beyond the bounds.
        Vector3 outBoundVec = Vector3.zero;

        if (futurePos.x > camRight)
        {
            outBoundVec.x += futurePos.x - camRight;
        }
        else if (futurePos.x < camLeft)
        {
            outBoundVec.x += futurePos.x - camLeft; 
        }

        if (futurePos.y > camTop)
        {
            outBoundVec.y += futurePos.y - camTop;
        }
        else if (futurePos.y < camButton)
        {
            outBoundVec.y += futurePos.y - camButton;
        }

        //If the future positon is not out of bounds.
        if (outBoundVec == Vector3.zero)
        {
            return Vector3.zero;
        }

        //If the future position is out of bounds, 
        //calculate the point the monster will leave the bounds, and the distance to it.
        Vector3 outBoundPos = futurePos - outBoundVec;
        float disToBound = Vector3.Distance(movementManager.Position, outBoundPos);

        //Add a flee force away from the leaving point with a weight
        //anti-proportional to the distance.
        Vector3 force = (10f / disToBound) * FleeForce(outBoundPos);

        return force;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawSphere(GetFuturePosition(1f), 0.1f);
        Gizmos.DrawLine(transform.position, transform.position + CalcSteeringForce());
    }
}
