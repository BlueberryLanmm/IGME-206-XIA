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
    [SerializeField]
    private float maxForce;

    //Camera bound for wall bouncing.
    [SerializeField]
    private new Camera camera;
    private float camLeft;
    private float camRight;
    private float camTop;
    private float camButton;

    #region Properties
    public float MaxSpeed
    {
        get {return maxSpeed;}
    }

    public float MaxForce
    {
        get { return maxForce; }
    }

    public Vector3 Velocity
    {
        get { return velocity; }
    }
    #endregion

    private void Awake()
    {
        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Calculate the camera bound.
        camLeft = -camera.orthographicSize * camera.aspect;
        camRight = camera.orthographicSize * camera.aspect;
        camButton = -camera.orthographicSize;
        camTop = camera.orthographicSize;

        //Initialize the starting postion and velocity.
        RandomSpawn();
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
        if (force.magnitude > Mathf.Pow(maxForce, 2))
        {  
            force = force.normalized * maxForce; 
        }        

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

    /// <summary>
    /// Bounce the monster b
    /// </summary>
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

    /// <summary>
    /// Respawn the monster at a random position within camera range.
    /// </summary>
    public void RandomSpawn()
    {
        Vector3 spawnPosition =
            new Vector3(
                Random.Range(camLeft, camRight),
                Random.Range(camButton, camTop),
                0);

        transform.position = spawnPosition;
        position = transform.position;
    }
}
