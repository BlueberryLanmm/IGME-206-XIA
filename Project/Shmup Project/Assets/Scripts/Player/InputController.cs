using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class InputController : MonoBehaviour
{
    private PlayerMovement movementController;
    private PlayerWeapons weaponController;

    private InputActionAsset inputActionAsset;
    private InputActionMap inputActionMap;
    private InputAction Move;
    private InputAction Fire;

    private void Awake()
    {
        inputActionAsset = GetComponent<PlayerInput>().actions;
        inputActionMap = inputActionAsset.FindActionMap("Player");
        Move = inputActionMap.FindAction("Move");
        Fire = inputActionMap.FindAction("Fire");

        movementController = GetComponent<PlayerMovement>();
        weaponController = GetComponent<PlayerWeapons>();

        inputActionAsset.Enable();
    }

    private void Start()
    {

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        movementController.UpdateDrivingForce(input);
    }

    public void OnFireMissile(InputAction.CallbackContext context)
    {
        bool isTriggered = context.performed;

        weaponController.IsTriggered = isTriggered;
    }
}
