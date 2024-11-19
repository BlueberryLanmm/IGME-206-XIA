using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseTracker : MonoBehaviour
{
    private PhysicsObject physics;
    private Camera camera;

    [SerializeField]
    private float forceMult;
    [SerializeField]
    private bool debugMode;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        physics = GetComponent<PhysicsObject>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Calculate the mouse force.
        Vector3 force = MousePosition() - transform.position;
        physics.ApplyForce(force * forceMult);

        if (debugMode)
        {
            Debug.Log(force);
        }
    }

    private Vector3 MousePosition()
    {
        //Calculate mouse position.
        Vector3 posInScreen = Mouse.current.position.ReadValue();
        Vector3 posInWorld = camera.ScreenToWorldPoint(posInScreen);

        return new Vector3(posInWorld.x, posInWorld.y, 0);
    }
}
