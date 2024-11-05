using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    private Vector3 objectiPosition = new Vector3(0, 0, 0);
    private float speed = 4f;
    private Vector3 direction = new Vector3(1, 0, 0);
    private Vector3 velocity = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        objectiPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = speed * direction * Time.deltaTime;
        
        objectiPosition += velocity;

        transform.position = objectiPosition;
    }
}
