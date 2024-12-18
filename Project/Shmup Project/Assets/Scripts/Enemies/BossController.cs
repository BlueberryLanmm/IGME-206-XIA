using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
    [Header("Movement Properties")]
    [SerializeField]
    private float startSpeed;
    [SerializeField]
    private float stopTime;

    private Vector2 position;
    private Vector2 velocity;

    //Player parameters
    private SpriteRenderer playerBoxRenderer;

    //Component references
    private SpriteRenderer enemyBoxRenderer;
    private EnemyStatus enemyStatus;

    //This is for fire type managing, not used currently.
    [Header("Weapon Types")]
    [SerializeField, Tooltip("Add attached fire types to the list.")]
    private List<EnemyFires> fireTypes;


    private void Awake()
    {
        //Component references
        enemyBoxRenderer = GetComponent<SpriteRenderer>();
        enemyStatus = GetComponent<EnemyStatus>();

        //Player reference
        playerBoxRenderer = enemyStatus.Player.GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        position = transform.position;
        velocity = startSpeed * transform.up;
    }

    #region Movement Control
    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        //Move the boss into the scene.
        if (velocity.sqrMagnitude < 0.05f)
        {
            velocity = Vector2.zero;
        }
        else
        {
            //Decelerate within a given stop time.
            velocity -=
                ((Vector2)transform.up *
                (startSpeed * Time.deltaTime / stopTime));
        }

        position += velocity * Time.deltaTime;
        transform.position = position;
    }
    #endregion


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

            //If hit player, tell the enemystatus to crash.
            //The crash damage dealt to boss is canceled.
            enemyStatus.ReceiveDamage(0, true);
        }
    }
}
