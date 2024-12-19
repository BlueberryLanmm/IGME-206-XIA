using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private int EnemyLevel = 0;
    [SerializeField]
    private GameObject boss;

    //Manage enemy list.
    [SerializeField]
    private List<Enemy> enemies;

    //Camera parameters
    private float camLeft;
    private float camRight;
    private Camera camera;


    private void Awake()
    {
        //Camera reference
        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        camLeft = -camera.orthographicSize * camera.aspect;
        camRight = camera.orthographicSize * camera.aspect;

        //Reset the initial spawn wait time to be the first spawn time.
        foreach (Enemy enemy in enemies)
        {
            enemy.SpawnInterval *= MathF.Pow(0.9f, EnemyLevel);
            enemy.SpawnTimer = enemy.FirstSpawnTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        foreach (Enemy enemy in enemies)
        {
            if (enemy.IsBoss && boss != null)
            {
                continue;
            }

            enemy.SpawnTimer -= Time.deltaTime;

            if (enemy.SpawnTimer < 0)
            {
                Vector2 spawnPosition = new Vector2(
                        transform.position.x,
                        transform.position.y);

                if (!enemy.IsBoss)
                {
                    spawnPosition.x = UnityEngine.Random.Range(camLeft, camRight);
                }

                //Instantiate the enemy as a child of Enemy Manager.
                GameObject newEnemy = 
                    GameObject.Instantiate(
                    enemy.Prefab,
                    spawnPosition,
                    transform.rotation,
                    transform);

                newEnemy.GetComponent<EnemyStatus>().IsBoss = enemy.IsBoss;

                if (enemy.IsBoss)
                {
                    boss = newEnemy;
                }

                //Reset the spawn timer to be the interval.
                enemy.SpawnTimer = enemy.SpawnInterval;
            }
        }
    }

    public void LevelUp()
    {
        foreach (Enemy enemy in enemies)
        {
            enemy.SpawnInterval *= 0.9f;
        }

        EnemyLevel += 1;
    }
}

/// <summary>
/// Define a new Enemy class, so that it is easier to manage
/// enemy types and their spawn info in the inspector.
/// </summary>
[Serializable]
public class Enemy
{
    private float spawnTimer;

    //The prefab of this type of enemy.
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private bool isBoss;
    //The spawn interval of this type of enemy.
    [SerializeField]
    private float spawnInterval;
    //When will the enemy spawn for the first time.
    [SerializeField]
    private float firstSpawnTime;

    #region Properties
    public GameObject Prefab
    { 
        get { return prefab; } 
    }

    public bool IsBoss
    { 
        get { return isBoss; } 
    }

    public float SpawnInterval
    {
        get { return spawnInterval; }

        set { spawnInterval = value; }
    }

    public float FirstSpawnTime
    {
        get { return firstSpawnTime; }
    }

    public float SpawnTimer
    { 
        get { return spawnTimer; } 
        
        set { spawnTimer = value; } 
    }
    #endregion
}
