using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockNumbers : MonoBehaviour
{
    //The prefab to be instantiate
    [SerializeField]
    private GameObject clockNumber;
    //Use a TextMesh variable to store and change the number.
    private TextMesh textMesh;
    //Use a redius to locate the numbers at a correct radius.
    [SerializeField]
    private float radius;

    //A clock has 12 numbers.
    const int TotalNumber = 12;

    // Start is called before the first frame update
    void Start()
    {
        //Calculate angle space between numbers.
        float space = (float) 360 / TotalNumber;

        //Use a for loop to locate all numbers
        for (int i = 1; i < TotalNumber + 1; i++)
        {
            //Calculate the radian angle of each number
            float radian = space * i * (Mathf.PI / 180);

            //Calculate the position of each number using the radian angle.
            Vector2 position = new Vector2(
                radius * Mathf.Sin(radian), 
                radius * Mathf.Cos(radian));

            //Instantiate a prefab as a child, and store its TextMesh component.
            textMesh = GameObject.Instantiate(
                clockNumber, position, Quaternion.identity, this.transform)
                .GetComponent<TextMesh>();

            //Change the number text.
            textMesh.text = string.Format($"{i}");
        }
    }
}
