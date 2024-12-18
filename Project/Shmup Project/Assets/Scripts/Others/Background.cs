using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    private float spawnTimer;

    [SerializeField]
    private GameObject starPrefab;

    //Camera parameters
    private float camLeft;
    private float camRight;
    private float camBottom;
    private float camTop;
    private Camera camera;


    private void Awake()
    {
        //Camera reference
        camera = Camera.main;
    }

    private void Start()
    {
        camLeft = -camera.orthographicSize * camera.aspect;
        camRight = camera.orthographicSize * camera.aspect;
        camBottom = -camera.orthographicSize;
        camTop = camera.orthographicSize;

        spawnTimer = 0f;

        //Spawn some stars at the beginning.
        SpawnStars(camLeft, camRight, camBottom, camTop, 200);
    }

    private void Update()
    {
        //Spawn some stars per frame.

        spawnTimer -= Time.deltaTime;

        if (spawnTimer < 0)
        {
            spawnTimer = 1f;

            SpawnStars(camLeft, camRight, camTop, camTop + 1, 10);
        }
    }

    /// <summary>
    /// Spawn stars within a box at a given number.
    /// </summary>
    /// <param name="xMin"></param>
    /// <param name="xMax"></param>
    /// <param name="yMin"></param>
    /// <param name="yMax"></param>
    /// <param name="Number"></param>
    private void SpawnStars(
        float xMin, float xMax, 
        float yMin, float yMax, 
        int Number)
    {
        for (int i = 0; i < Number; i++)
        {
            Vector2 spawnPos = 
                new Vector2(Random.Range(xMin, xMax) , Random.Range(yMin, yMax));

            GameObject.Instantiate(
                starPrefab,
                spawnPos,
                transform.rotation,
                transform);
        }
    }
}
