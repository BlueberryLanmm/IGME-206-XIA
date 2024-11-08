using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Vector3 objectPosition = new Vector3(0, 0, 0);
    [SerializeField]
    private float speed = 4f;
    private Vector3 direction = new Vector3(0, 0, 0);
    private Vector3 velocity = new Vector3(0, 0, 0);

    //Calculate screen size
    private Vector3 screenExtent;
    private float camLeft;
    private float camRight;
    private float camTop;
    private float camBottom;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the objectPosition to vehicle starting position
        objectPosition = transform.position;

        //Calculate camera size in world unit.
        screenExtent = new Vector3(
            Camera.main.orthographicSize * Camera.main.aspect, 
            Camera.main.orthographicSize,
            0);

        //Calculate 4 edges of the screen
        camLeft = -screenExtent.x;
        camRight = screenExtent.x;
        camTop = screenExtent.y;
        camBottom = -screenExtent.y;
    }

    // Update is called once per frame
    void Update()
    {
        //Teleport to the other edge when reach the boundary horizontally.
        if (objectPosition.x > camRight)
        {
            objectPosition.x = camLeft;
        }
        if (objectPosition.x < camLeft)
        {
            objectPosition.x = camRight;
        }

        //Teleport to the other edge when reach the boundary vertically.
        if (objectPosition.y > camTop)
        {
            objectPosition.y = camBottom;
        }
        if (objectPosition.y < camBottom)
        {
            objectPosition.y = camTop;
        }

        //Apply vehicle movement according to time
        velocity = speed * direction * Time.deltaTime;        
        objectPosition += velocity;
        transform.position = objectPosition;
    }

    public void SetDirection(Vector3 direction)
    {
        //Do the rotation when there is actual direction change
        if (direction != Vector3.zero)
        {
            //Set the vehicle's rotation to match the direction
            transform.rotation = Quaternion.LookRotation(Vector3.back, direction);
        }

        //Set the current direction to modify velocity.
        this.direction = direction;
    }
}
