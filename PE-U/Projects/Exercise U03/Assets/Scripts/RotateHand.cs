using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHand : MonoBehaviour
{
    //The amount of turn per unit time/per frame.
    private float turnAmount;
    //Whether this object use Time.DeltaTime() when rotating.
    [SerializeField]
    private bool useDeltaTime;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize the turnAmount so that it completes one
        //complete rotation around the clock every minute.
        turnAmount = 6;

        //Rotate the arrow to up direction at first.
        Quaternion rotation = Quaternion.Euler(0, 0, -90);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // If the DeltaTime is applied
        if (useDeltaTime)
        {
            //Rotate the arrow at a constant speed per unit time.
            transform.Rotate(0, 0, -turnAmount * Time.deltaTime);
        }
        // If not applied
        else
        {
            //Rotate the arrow at a constant speed per frame.
            transform.Rotate(0, 0, -turnAmount / 100);
        }

    }
}
