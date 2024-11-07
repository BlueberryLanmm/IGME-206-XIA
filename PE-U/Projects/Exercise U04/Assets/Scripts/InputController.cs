using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    Vector2 inputDirection = Vector2.zero;
    MovementController myMovementController;

    // Start is called before the first frame update
    void Start()
    {
        myMovementController = GetComponent<MovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the latest value for the input from the Input System
        inputDirection = context.ReadValue<Vector2>();  // This is already normalized for us

        // Send that new direction to the Vehicle class
        myMovementController.SetDirection(inputDirection);
    }
}
