using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CollisionDetect : MonoBehaviour
{
    [SerializeField]
    private bool isAABB;

    [SerializeField]
    private GameObject vehicle;

    //The colliderRadius when using bouding circle detection.
    //The radius of vehicle is a property of MovementController class.
    private float collideRadius = 0.6f;
    private float vehicleCollideRadius;

    //Detect if is current collided.
    private bool isColliding = false;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer vehicleSpriteRenderer;
    private VehicleCollision vehicleCollision;

    public bool DetectionMode
    {
        get { return isAABB; }

        set { isAABB = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the 2 spriteRenderer components.
        spriteRenderer = GetComponent<SpriteRenderer>();
        vehicleSpriteRenderer = vehicle.GetComponent<SpriteRenderer>();

        //Get the vehicle's collide detection component.
        vehicleCollision = vehicle.GetComponent<VehicleCollision>();
        vehicleCollideRadius = vehicleCollision.CollideRadius;

        //If the obstacle is bigger, multiply radius with scale.
        collideRadius *= transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Check the collision detect mode.
        if (isAABB)
        {
            AABBDetect();
        }
        else
        {
            BoundingCircleDetect();
        }
    }

    private void AABBDetect()
    {
        //4 bounds for this obstacle
        float obstacleRight = spriteRenderer.bounds.max.x;
        float obstacleLeft = spriteRenderer.bounds.min.x;
        float obstacleTop = spriteRenderer.bounds.max.y;
        float obstacleButton = spriteRenderer.bounds.min.y;

        //Debug.Log(string.Format("{0}, {1}, {2}, {3}",
        //    obstacleRight,
        //    obstacleLeft,
        //    obstacleTop,
        //    obstacleButton));

        //4 bounds for the vehicle
        float vehicleRight = vehicleSpriteRenderer.bounds.max.x;
        float vehicleLeft = vehicleSpriteRenderer.bounds.min.x;
        float vehicleTop = vehicleSpriteRenderer.bounds.max.y;
        float vehicleButton = vehicleSpriteRenderer.bounds.min.y;

        //Debug.Log(string.Format("{0}, {1}, {2}, {3}",
        //    vehicleRight,
        //    vehicleLeft,
        //    vehicleTop,
        //    vehicleButton));

        //Detect the collision by boundaries.
        if (obstacleLeft < vehicleRight &&
            obstacleRight > vehicleLeft &&
            obstacleButton < vehicleTop &&
            obstacleTop > vehicleButton )
        {
            if (!isColliding)
            {
                isColliding = true;

                //Change the sprite color if the obstacle starts collision.
                spriteRenderer.color = Color.red;
                vehicleCollision.CollisionCount += 1;
            }
        }
        else  
        {
            if (isColliding)
            {
                isColliding = false;

                spriteRenderer.color = Color.white;
                vehicleCollision.CollisionCount -= 1;
            }
        }
    }

    private void BoundingCircleDetect()
    {
        //Detect collision by distance between vehicle and obstacle.
        bool collideOccur = 
            Mathf.Pow(transform.position.x - vehicle.transform.position.x, 2) +
            Mathf.Pow(transform.position.y - vehicle.transform.position.y, 2) < 
            Mathf.Pow(vehicleCollideRadius + collideRadius, 2);

        if (collideOccur)
        {
            if (!isColliding)
            {
                isColliding = true;

                //Change the sprite color if the obstacle is in collision.
                spriteRenderer.color = Color.red;
                vehicleCollision.CollisionCount += 1;
            }
        }
        else 
        {
            if (isColliding)
            {
                isColliding = false;

                spriteRenderer.color = Color.white;
                vehicleCollision.CollisionCount -= 1;
            }
        }
    }
        
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        if (spriteRenderer != null &&
            vehicleSpriteRenderer != null)
        {
            //If is in AABB detection mode, draw the diagonal of colliders.
            if (isAABB)
            {
                Gizmos.DrawLine(spriteRenderer.bounds.min,
                    spriteRenderer.bounds.max);
                Gizmos.DrawLine(vehicleSpriteRenderer.bounds.min,
                    vehicleSpriteRenderer.bounds.max);
            }
            //If is in bounding circle detection mode, draw the collide sphere.
            else
            {
                Gizmos.DrawWireSphere(transform.position, collideRadius);
                Gizmos.DrawWireSphere(vehicle.transform.position, vehicleCollideRadius);
            }
        }


    }
}
