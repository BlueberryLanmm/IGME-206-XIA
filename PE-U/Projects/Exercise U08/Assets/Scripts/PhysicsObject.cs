using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    private Vector3 position;
    private Vector3 direction;
    private Vector3 velocity;
    private Vector3 acceleration;

    [SerializeField]
    private float mass;

    //Friction parameter
    [SerializeField]
    private bool applyFriction;
    [SerializeField]
    private float coefficient;

    //Gravity parameter
    [SerializeField]
    private bool applyGravity;
    [SerializeField]
    private float gravityScale;

    [SerializeField]
    private float maxSpeed;

    //Camera bound for wall bouncing.
    [SerializeField]
    private new Camera camera;
    private float camLeft;
    private float camRight;
    private float camTop;
    private float camButton;

    public float MaxSpeed
    {
        get {return maxSpeed;}
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calculate the camera bound.
        camera = Camera.main;
        camLeft = -camera.orthographicSize * camera.aspect;
        camRight = camera.orthographicSize * camera.aspect;
        camButton = -camera.orthographicSize;
        camTop = camera.orthographicSize;

        //Initialize the starting postion and velocity.
        position = transform.position;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Detect walls and apply bouncing.
        DetectWall();
        
        //Check whether to apply friction and gravity.
        if (applyFriction)
        {
            ApplyFriction(coefficient);
        }

        if (applyGravity)
        {
            ApplyGravity(gravityScale);
        }

        //Apply movement.
        velocity += acceleration * Time.deltaTime;
        //Limit the speed less than max speed.
        if (velocity.sqrMagnitude > Mathf.Pow(maxSpeed, 2))
        {
            velocity = velocity.normalized * maxSpeed;
        }

        position += velocity * Time.deltaTime;
        direction = velocity.normalized;

        transform.position = position;
        transform.up = direction;

        //Reset the acceleration at frame end.
        acceleration = Vector3.zero;
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    private void ApplyGravity(float gravityScale)
    {
        //Apply gravity as a force upwards.
        Vector3 gravity = new Vector3(0, -1, 0) * gravityScale;
        ApplyForce(gravity * mass);
    }


    private void ApplyFriction(float coeff)
    {
        //Apply friction as a force opposite to the direction.
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;
        ApplyForce(friction);
    }

    private void DetectWall()
    {
        //When the monster goes outside the wall, teleport it back.
        Vector3 newPosition = transform.position;

        //Reverse the speed when touch the wall.
        if (newPosition.x <= camLeft)
        {
            newPosition.x = camLeft + 0.05f;
            velocity.x = Mathf.Abs(velocity.x);
        }
        if (newPosition.x >= camRight)
        {
            newPosition.x = camRight - 0.05f;
            velocity.x = -Mathf.Abs(velocity.x);
        }
        if (newPosition.y <= camButton)
        {
            newPosition.y = camButton + 0.05f;
            velocity.y = Mathf.Abs(velocity.y);
        }
        if (newPosition.y >= camTop)
        {
            newPosition.y = camTop - 0.05f;
            velocity.y = -Mathf.Abs(velocity.y);
        }

        transform.position = newPosition;
    }
}
