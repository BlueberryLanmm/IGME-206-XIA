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
    //When in animation, stop input and some detections.
    private bool inAnimation;

    [SerializeField, Tooltip("How fast the ship accelerates when press buttons.")]
    private float accelerateSpeed;
    [SerializeField,Tooltip("The max speed when keep pressing button.")]
    private float maxSpeed;
    [SerializeField,Tooltip("How fast the ship slows down when input stops.")]
    private float frictionCoeff;

    [Header("References")]

    //Camera parameters
    private float camLeft;
    private float camRight;
    private float camTop;
    private float camButton;
    [SerializeField]
    private Camera camera;

    //Renderer parameters
    private SpriteRenderer playerRenderer;


    //Make references in Awake()
    private void Awake()
    {
        //Camera reference
        camera = Camera.main;

        //Renderer reference
        playerRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    //Make initializations in Start()
    void Start()
    {
        //Initialize movement parameters
        position = transform.position;
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

        StartCoroutine(FlyIn());
    }

    //Update forces and acceleration every frame.
    private void Update()
    {

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
        acceleration = Vector2.zero;
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
        if (inAnimation)
        {
            return;
        }

        drivingForce = input * accelerateSpeed;
    }
    #endregion

    #region Edge Detect Functions
    private void DetectEdge()
    {
        if (inAnimation)
        {
            return;
        }

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

    #region Animations
    /// <summary>
    /// This is the move-in animation for player ship at game start.
    /// </summary>
    /// <returns>This blocks input for 2s from the begginning.</returns>
    private IEnumerator FlyIn()
    {        
        velocity = maxSpeed * Vector2.up;
        drivingForce = accelerateSpeed * Vector2.up;
        inAnimation = true;

        yield return new WaitForSeconds(0.5f);

        drivingForce = Vector2.zero;

        yield return new WaitForSeconds(1f);

        inAnimation = false;
        StartCoroutine(Blink());
    }

    /// <summary>
    /// This is the blink effect for player ship in special cases.
    /// </summary>
    /// <returns>This does not block input.</returns>
    private IEnumerator Blink()
    {
        for (int i = 0; i < 3; i++)
        {
            playerRenderer.color = Color.clear;

            yield return new WaitForSeconds(0.2f);

            playerRenderer.color = Color.white;

            yield return new WaitForSeconds(0.2f);
        }
    }
    #endregion
}
