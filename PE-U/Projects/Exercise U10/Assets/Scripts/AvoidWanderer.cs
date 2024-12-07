using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidWanderer : Agents
{
    [SerializeField]
    private float lookAheadTime;

    //Avoid fields
    [SerializeField]
    protected GameObject obstacleManager;
    private Obstacle[] obstacles;
    [SerializeField]
    private float avoidingRadius;

    private float forwardLimit;
    private float rightLimit;

    [SerializeField]
    private float wanderRadius;
    [SerializeField]
    private float wanderAngle;


    private float currentWanderAngle = 0;

    private new void Awake()
    {
        base.Awake();

        if (obstacleManager != null )
        {
            obstacles = obstacleManager.GetComponentsInChildren<Obstacle>();

            foreach ( Obstacle obstacle in obstacles )
            {
                Debug.Log(obstacle.name);
            }
        }
    }

    protected override Vector3 CalcSteeringForce()
    {
        Vector3 force = StayInBoundsForce(lookAheadTime);

        force += WanderForce(ref currentWanderAngle, wanderAngle,
           3 * wanderAngle, lookAheadTime, wanderRadius);

        force += AvoidObstacleForce(BadObstacles(lookAheadTime));

        return force;
    }

    private List<Obstacle> BadObstacles(float lookAheadTime)
    {
        List<Obstacle> badObstacles = new List<Obstacle>();

        forwardLimit = movementManager.Velocity.magnitude * lookAheadTime;
        rightLimit = 0;

        foreach (Obstacle obstacle in obstacles)
        {
            Vector3 localPosition = obstacle.transform.position - movementManager.Position;

            float forward = Vector3.Dot(transform.up, localPosition);
            float right = Vector3.Dot(transform.right, localPosition);

            rightLimit = avoidingRadius + obstacle.Radius;

            //If the obstacle is blocking the path, it is a bad obstacle.
            if ((forward > 0 && forward < forwardLimit) &&
                (Mathf.Abs(right) < rightLimit))
            {
                badObstacles.Add(obstacle);
            }
        }

        return badObstacles;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(
            transform.position, 
            transform.position + movementManager.Velocity.normalized * forwardLimit);

        Gizmos.DrawWireSphere(transform.position, avoidingRadius);
    }
}
