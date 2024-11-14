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

    [SerializeField]
    private bool applyFriction;
    [SerializeField]
    private float coefficient;

    [SerializeField]
    private bool applyGravity;
    [SerializeField]
    private float gravityScale;

    [SerializeField]
    private float maxSpeed;

    private Camera camera;
    private Vector3 cameraSize;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        position = transform.position;
        velocity = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        acceleration = Vector3.zero;
        
        if (applyFriction)
        {
            ApplyFriction(coefficient);
        }

        if (applyGravity)
        {
            ApplyGravity(gravityScale);
        }

        velocity += acceleration * Time.deltaTime;
        position += velocity * Time.deltaTime;
        direction = velocity.normalized;

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(direction);
    }

    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    void ApplyGravity(float gravityScale)
    {
        Vector3 gravity = new Vector3(0, -1, 0) * gravityScale;
        ApplyForce(gravity * mass);
    }


    void ApplyFriction(float coeff)
    {
        Vector3 friction = velocity * -1;
        friction.Normalize();
        friction = friction * coeff;
        ApplyForce(friction);
    }
}
