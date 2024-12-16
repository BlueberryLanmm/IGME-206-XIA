using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MissileController : MonoBehaviour
{
    [SerializeField]
    private int damage;
    [SerializeField]
    private float startSpeed;
    [SerializeField]
    private float maxSpeed;

    //Movement parameters
    private Vector2 position;
    private Vector2 velocity;
    private Vector2 direction;

    private Vector2 acceleration;
    private Vector2 drivingForce;

    //Camera parameters
    private float camLeft;
    private float camRight;
    private float camButton;
    private float camTop;
    private Camera camera;

    //Renderer parameters
    private SpriteRenderer spriteRenderer;

    //Targets Reference
    private GameObject enemyManager;
    protected Transform[] targets;
    protected SpriteRenderer[] targetRenderers;


    #region Properties
    public Vector2 Velocity
    {
        get { return velocity; }
    }

    public Vector2 Direction
    {
        get { return direction; }
    } 

    public int Damage
    { 
        get { return damage; } 

        set { damage = value; }
    }

    public float MaxSpeed
    {
        get { return maxSpeed; }
    }
    #endregion


    private void Awake()
    {
        //Camera reference
        camera = Camera.main;

        //Reference the enemy manager.
        try
        {
            enemyManager = GameObject.Find("Enemy Manager");
        }
        catch
        {
            Debug.Log("Can't find Enemy Manager. Missile spawn failed.");
            GameObject.Destroy(gameObject);
        }

        //Renderer reference
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        //Initialize movement parameters
        position = transform.position;
        direction = transform.up;
        //Initializae the veleocity according to the direction.
        velocity = startSpeed * direction;

        acceleration = Vector2.zero;
        drivingForce = Vector2.zero;

        //Initialize camera parameters
        camLeft = -camera.orthographicSize * camera.aspect -
            spriteRenderer.bounds.extents.x;
        camRight = camera.orthographicSize * camera.aspect +
            spriteRenderer.bounds.extents.x;
        camButton = -camera.orthographicSize -
            spriteRenderer.bounds.extents.y;
        camTop = camera.orthographicSize +
            spriteRenderer.bounds.extents.y;
    }

    private void FixedUpdate()
    {
        ApplyMovement();
        DetectEdge();
    }

    #region Movements
    private void ApplyMovement()
    {
        ApplyForce(drivingForce);

        velocity += acceleration * Time.deltaTime;
        direction = velocity.normalized;

        position += velocity * Time.deltaTime;
        transform.position = position;
        transform.up = direction;

        //Reset the acceleration at frame end.
        acceleration = Vector2.zero;

        if (velocity.sqrMagnitude > Mathf.Pow(maxSpeed, 2)) 
        {
            velocity = velocity.normalized * maxSpeed;
        }             
    }

    private void ApplyForce(Vector2 force)
    {
        acceleration += force;
    }

    protected void UpdateDrivingForce(Vector2 input)
    {
        drivingForce = input;
    }

    private void DetectEdge()
    {
        Vector3 newPosition = transform.position;

        //Clear the velocity when touch the wall.
        if (newPosition.x < camLeft ||
            newPosition.x > camRight ||
            newPosition.y < camButton ||
            newPosition.y > camTop)
        {
            GameObject.Destroy(gameObject);
        }
    }
    #endregion

    protected void Update()
    {
        DetectCollision();
    }

    #region Hitting Target
    private void DetectCollision()
    {
        //For enemy missiles, find player when aim the first time.
        if (gameObject.CompareTag("EnemyMissile"))
        {
            if (targets == null)
            {
                targets = new Transform[1];
                targetRenderers = new SpriteRenderer[1];

                #region Find Player
                try
                {
                    targets[0] = GameObject.FindGameObjectWithTag("Player").transform;
                    targetRenderers[0] = targets[0].GetComponent<SpriteRenderer>();
                }
                catch
                {
                    Debug.Log("Can't find player. Missile aim failed.");
                    GameObject.Destroy(gameObject);
                }
                #endregion
            }
        }

        //For player missiles, update enemy list every frame.
        if (gameObject.CompareTag("PlayerMissile"))
        {
            //Get all children of enemyManager as the targets.
            targets = enemyManager.GetComponentsInChildren<Transform>();
            targetRenderers = enemyManager.GetComponentsInChildren<SpriteRenderer>();            
        }

        //Use the AABB collision detection, and return the detected target.
        foreach (SpriteRenderer targetRenderer in targetRenderers)
        {
            float missileRight = spriteRenderer.bounds.max.x;
            float missileLeft = spriteRenderer.bounds.min.x;
            float missileTop = spriteRenderer.bounds.max.y;
            float missileButton = spriteRenderer.bounds.min.y;

            float targetRight = targetRenderer.bounds.max.x;
            float targetLeft = targetRenderer.bounds.min.x;
            float targetTop = targetRenderer.bounds.max.y;
            float targetButton = targetRenderer.bounds.min.y;

            if (missileLeft < targetRight &&
                missileRight > targetLeft &&
                missileTop > targetButton &&
                missileButton < targetTop)
            {
                //If collide with sprite instead of player/enemy box, do not return it.
                if (!targetRenderer.CompareTag("Player") &&
                    !targetRenderer.CompareTag("Enemy"))
                {
                    continue;
                }

                MissileHit(targetRenderer.transform);

                return;
            }
        }
    }

    private void MissileHit(Transform target)
    {
        if (target == null)
        {
            return;
        }

        if (gameObject.CompareTag("EnemyMissile"))
        {
            //Debug.Log("Missile hit player!");
            target.GetComponent<PlayerStatus>().Health -= Damage;
            GameObject.Destroy(gameObject);
        }

        if (gameObject.CompareTag("PlayerMissile"))
        {
            Debug.Log("Missile hit enemy!");
            target.GetComponent<EnemyStatus>().ReceiveDamage(Damage);
            GameObject.Destroy(gameObject);
        }
    }
    #endregion
}
