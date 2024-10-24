using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class testScript : MonoBehaviour
{
    public string myName;

    // Start is called before the first frame update
    void Start()
    {
        myName = "Earl";
        Debug.Log("I am alive and my name is " + myName); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
