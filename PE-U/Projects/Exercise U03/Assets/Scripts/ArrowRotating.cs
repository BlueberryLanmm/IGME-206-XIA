using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotating : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, -90);
        transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -rotateSpeed * Time.deltaTime);
    }
}
