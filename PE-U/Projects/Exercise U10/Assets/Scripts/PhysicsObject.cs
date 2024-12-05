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

    #region Properties
    public float MaxSpeed
    {
        get {return maxSpeed;}
    }

    public float MaxForce
    {
        get { return maxForce; }
    }

    public Vector3 Position
    { get { return position; } }

    public Vector3 Velocity
    {
        get { return velocity; }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the starting postion and velocity.
        position = transform.position;

        float startAngle = Random.Range(0, 360);
        velocity = new Vector3(
            Mathf.Cos(startAngle * Mathf.Deg2Rad),
            Mathf.Sin(startAngle * Mathf.Deg2Rad),
            0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
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

    public void ApplyForce(Vector3 force, bool applyLimit)
    {
        if (applyLimit && force.magnitude > Mathf.Pow(maxForce, 2))
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
}
