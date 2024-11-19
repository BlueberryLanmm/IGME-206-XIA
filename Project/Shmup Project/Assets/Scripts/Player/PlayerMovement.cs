using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Properties")]
    private Vector2 position;
    private Vector2 velocity;
    private Vector2 drivingForce;
    private Vector2 acceleration;

    [SerializeField, Tooltip("How fast the ship accelerates when press buttons.")]
    private float accelerateSpeed;
    [SerializeField,Tooltip("The max speed when keep pressing button.")]
    private float maxSpeed;
    [SerializeField,Tooltip("How fast the ship slows down when input stops.")]
    private float frictionCoeff;


    [Header("Weapon Properties")]
    [SerializeField]
    private float ShootSpeed;


    [Header("References")]

    //Camera parameters
    private float camLeft;
    private float camRight;
    private float camTop;
    private float camButton;
    [SerializeField]
    private Camera camera;

    //Renderer parameters
    [SerializeField]
    private SpriteRenderer playerRenderer;


    //Make references in Awake()
    private void Awake()
    {
        //Camera reference
        camera = Camera.main;

        //Renderer reference
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    //Make initializations in Start()
    void Start()
    {
        //Initialize movement parameters
        position = Vector2.zero;
        velocity = Vector2.zero;
        acceleration = Vector2.zero;

        //Initialize camera parameters
        camLeft = -camera.orthographicSize * camera.aspect + 
            playerRenderer.bounds.extents.x;
        camRight = camera.orthographicSize * camera.aspect -
            playerRenderer.bounds.extents.x;
        camButton = -camera.orthographicSize + 
            playerRenderer.bounds.extents.y;
        camTop = camera.orthographicSize - 
            playerRenderer.bounds.extents.y;
    }

    //Update forces and acceleration every frame.
    private void Update()
    {
        Debug.Log("Current acceleration:" + acceleration);
    }

    //Calculate velocity and position every fixed time.
    private void FixedUpdate()
    {
        ApplyMovement();
        DetectEdge();
    }

    #region Movement Calculation
    private void ApplyMovement()
    {
        ApplyForce(drivingForce);
        ApplyFriction(frictionCoeff);

        velocity += acceleration * Time.deltaTime;

        //Limit the speed less than max speed.
        if (velocity.sqrMagnitude > Mathf.Pow(maxSpeed, 2))
        {
            velocity = velocity.normalized * maxSpeed;
        }

        position += velocity * Time.deltaTime;
        transform.position = position;

        //Reset the acceleration at frame end.
        acceleration = Vector3.zero;
    }
    #endregion

    #region Force Functions
    private void ApplyForce(Vector2 force)
    {
        acceleration += force;
    }

    private void ApplyFriction(float coeff)
    {
        //Apply friction as a force opposite to the direction.
        Vector2 friction = velocity * -1;
        friction.Normalize();
        friction *= coeff;

        ApplyForce(friction);
    }

    public void UpdateDrivingForce(Vector2 input)
    {
        drivingForce = input * accelerateSpeed;
    }
    #endregion

    #region Edge Detect Functions
    private void DetectEdge()
    {
        //Define new position for relocating the ship.
        Vector3 newPosition = transform.position;
        float error = 0f;

        //Clear the velocity when touch the wall.
        if (newPosition.x < camLeft - error)
        {
            newPosition.x = camLeft;
            velocity.x = Mathf.Max(0, velocity.x);
        }
        if (newPosition.x > camRight + error)
        {
            newPosition.x = camRight;
            velocity.x = Mathf.Min(0, velocity.x);
        }
        if (newPosition.y < camButton - error)
        {
            newPosition.y = camButton;
            velocity.y = Mathf.Max(0, velocity.y);
        }
        if (newPosition.y > camTop + error)
        {
            newPosition.y = camTop;
            velocity.y = Mathf.Min(0, velocity.y);
        }

        transform.position = newPosition;
    }
    #endregion
}
