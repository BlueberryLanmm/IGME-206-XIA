using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [Header("Basic Properties")]
    private int health;

    private bool isBoss;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int scoreBonus;
    [SerializeField]
    private float energyBonus;

    private bool hasCrash;

    private EnemyManager enemyManager;
    private SpriteRenderer spriteRenderer;
    private GameObject player;
    private PlayerStatus playerStatus;


    #region Properties
    public GameObject Player
    {
        get { return player; }
    }

    public int Health
    {
        get { return health; }
    }

    public bool IsBoss
    { 
        get { return isBoss; } 

        set { isBoss = value; }
    }
    #endregion


    private void Awake()
    {
        enemyManager = transform.parent.GetComponent<EnemyManager>();
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();

        //Player reference
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerStatus = player.GetComponent<PlayerStatus>();
        }
        catch
        {
            Debug.Log("Can't find player. Enemy spawn failed.");
            GameObject.Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        DeathCheck();
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Blink());
    }

    public void ReceiveDamage(int damage, bool hasCrash)
    {
        this.hasCrash = hasCrash;
        health -= damage;

        //If the enemy is a boss, no damage will be dealt,
        //so it will not blink.
        if (isBoss)
        {
            return;
        }

        StartCoroutine(Blink());
    }

    public void DeathCheck()
    {
        if (playerStatus == null)
        {
            return;
        }    

        if (health <= 0 && !hasCrash)
        {
            //If enemy died, add to player score and energy.
            playerStatus.Score += scoreBonus;
            playerStatus.Energy += energyBonus;
        }
        //If enemy crash into the player, cause damage.
        else if (hasCrash)
        {
            playerStatus.ReceiveDamage(2);

            //Reset the hasCrash for boss crash detection.
            hasCrash = false;
        }
        
        //If enemy is still alive, return and do noting.
        if (health >0)
        {
            return;
        }

        if (isBoss)
        {
            playerStatus.Health += playerStatus.MaxHealth;
            enemyManager.LevelUp();
        }

        GameObject.Destroy(gameObject);
    }

    private IEnumerator Blink()
    {
        spriteRenderer.color = new Color(1f, 1f, 1f, 0f);

        yield return new WaitForSeconds(0.05f);

        spriteRenderer.color = Color.white;
    }
}
