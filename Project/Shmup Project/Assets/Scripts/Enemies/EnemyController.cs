using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    [Header("Movement Properties")]
    private Vector2 position;
    private Vector2 velocity;

    [SerializeField, Tooltip("The vertical speed of the enemy.")]
    private float verticalSpeed;
    [SerializeField, Tooltip("The maximum horizontal speed of the enemy.")]
    private float horizontalSpeed;


    //More fields required in children classes.
    [Header("Weapon Properties")]
    [SerializeField]
    protected GameObject missile;
    [SerializeField]
    protected float fireCooldown;


    /// <summary>
    /// References
    /// </summary>

    //Camera parameters
    private float camLeft;
    private float camRight;
    private float camButton;
    private Camera camera;

    //Player parameters
    private SpriteRenderer playerRenderer;

    //Component references
    private SpriteRenderer enemyRenderer;
    private EnemyStatus enemyStatus;


    protected void Awake()
    {
        //Camera reference
        camera = Camera.main;

        //Component references
        enemyRenderer = GetComponent<SpriteRenderer>();
        enemyStatus = GetComponent<EnemyStatus>();

        //Player reference
        playerRenderer = enemyStatus.Player.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
        //Initialize movement parameters
        position = transform.position;
        velocity = new Vector2(
            Random.Range(-horizontalSpeed, horizontalSpeed),
            -verticalSpeed);

        //Initialize camera parameters
        camLeft = -camera.orthographicSize * camera.aspect +
            enemyRenderer.bounds.extents.x;
        camRight = camera.orthographicSize * camera.aspect -
            enemyRenderer.bounds.extents.x;
        camButton = -camera.orthographicSize -
            enemyRenderer.bounds.extents.y;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        DetectEdge();
    }

    private void ApplyMovement()
    {
        position += velocity * Time.deltaTime;
        transform.position = position;
    }

    private void DetectEdge()
    {
        //Define new position for relocating the ship.
        Vector3 newPosition = transform.position;

        //Reverse the velocity when touch the wall.
        if (newPosition.x < camLeft)
        {
            newPosition.x = camLeft;
            velocity.x = Mathf.Abs(velocity.x);
        }
        if (newPosition.x > camRight)
        {
            newPosition.x = camRight;
            velocity.x = -Mathf.Abs(velocity.x);
        }
        //If goes outside the screen, destroy the enemy.
        if (newPosition.y < camButton)
        {
            GameObject.Destroy(gameObject);
            return;
        }

        transform.position = newPosition;
    }

    private void Update()
    {
        FireMissiles();
        DetectCollision();
    }

    protected abstract void FireMissiles();

    private void DetectCollision()
    {
        //Use the AABB collision detection 
        float enemyRight = enemyRenderer.bounds.max.x;
        float enemyLeft = enemyRenderer.bounds.min.x;
        float enemyTop = enemyRenderer.bounds.max.y;
        float enemyButton = enemyRenderer.bounds.min.y;

        float playerRight = playerRenderer.bounds.max.x;
        float playerLeft = playerRenderer.bounds.min.x;
        float playerTop = playerRenderer.bounds.max.y;
        float playerButton = playerRenderer.bounds.min.y;

        if (enemyRight > playerLeft &&
            enemyLeft < playerRight &&
            enemyTop > playerButton &&
            enemyButton < playerTop)
        {
            //Debug.Log("Enemy hit player!");

            //If hit player, deal maximum damage and crash.
            enemyStatus.ReceiveDamage(enemyStatus.Health, true);
        }
    }
}
