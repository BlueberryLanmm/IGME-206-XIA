using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Movement Properties")]
    private Vector2 position;
    private Vector2 velocity;

    [SerializeField, Tooltip("The vertical speed of the enemy.")]
    private float verticalSpeed;
    [SerializeField, Tooltip("The maximum horizontal speed of the enemy.")]
    private float horizontalSpeed;

    /// <summary>
    /// References
    /// </summary>

    //Camera parameters
    private float camLeft;
    private float camRight;
    private float camButton;
    private Camera camera;

    //Player parameters
    private SpriteRenderer playerBoxRenderer;

    //Component references
    private SpriteRenderer enemyBoxRenderer;
    private EnemyStatus enemyStatus;


    protected virtual void Awake()
    {
        //Camera reference
        camera = Camera.main;

        //Component references
        enemyBoxRenderer = GetComponent<SpriteRenderer>();
        enemyStatus = GetComponent<EnemyStatus>();

        //Player reference
        playerBoxRenderer = enemyStatus.Player.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        //Initialize movement parameters
        position = transform.position;
        velocity = new Vector2(
            Random.Range(-horizontalSpeed, horizontalSpeed),
            -verticalSpeed);

        //Initialize camera parameters
        camLeft = -camera.orthographicSize * camera.aspect +
            enemyBoxRenderer.bounds.extents.x;
        camRight = camera.orthographicSize * camera.aspect -
            enemyBoxRenderer.bounds.extents.x;
        camButton = -camera.orthographicSize -
            enemyBoxRenderer.bounds.extents.y;
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
        DetectCollision();
    }

    private void DetectCollision()
    {
        if (playerBoxRenderer == null)
        {
            return;
        }

        //Use the AABB collision detection 
        float enemyRight = enemyBoxRenderer.bounds.max.x;
        float enemyLeft = enemyBoxRenderer.bounds.min.x;
        float enemyTop = enemyBoxRenderer.bounds.max.y;
        float enemyButton = enemyBoxRenderer.bounds.min.y;

        float playerRight = playerBoxRenderer.bounds.max.x;
        float playerLeft = playerBoxRenderer.bounds.min.x;
        float playerTop = playerBoxRenderer.bounds.max.y;
        float playerButton = playerBoxRenderer.bounds.min.y;

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
