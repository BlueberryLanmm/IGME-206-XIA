using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const int AABBMode = 1;
    private const int CircleMode = -1;

    private int detectMode = AABBMode;

    [SerializeField]
    private GameObject obstacles;
    private CollisionDetect[] detectors;

    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        //Store all obstacles' CollisionDetect components.
        detectors = obstacles.GetComponentsInChildren<CollisionDetect>();
        textMesh = GetComponentInChildren<TextMesh>();

        //Debug.Log(textMesh.text);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMode();
    }

    private void ChangeMode()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Click the mounse to change the collision mode.
            detectMode *= -1;

            //Change all the obstacles' detection mode.
            foreach (CollisionDetect d in detectors)
            {
                d.DetectionMode = !d.DetectionMode;
            }

            //Change the text info.
            textMesh.text = detectMode > 0 ? 
                "AABB Mode" : "Bounding Circle Mode";
        }
    }
}
