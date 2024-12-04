using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [Header("Basic Properties")]
    private int health;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int scoreBonus;
    [SerializeField]
    private float energyBonus;

    private bool isHit;
    private bool hasCrash;

    private GameObject player;
    private PlayerStatus playerStatus;
    private SpriteRenderer playerRenderer;


    #region Properties
    public GameObject Player
    {
        get { return player; }
    }

    public int Health
    {
        get { return health; }
    }
    #endregion


    private void Awake()
    {
        //Player reference
        try
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerStatus = player.GetComponent<PlayerStatus>();
            playerRenderer = player.GetComponent<SpriteRenderer>();
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
        DeathCheck(hasCrash);
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
    }

    public void ReceiveDamage(int damage, bool hasCrash)
    {
        health -= damage;
        hasCrash = this.hasCrash;
    }

    public void DeathCheck(bool hasCrash)
    {
        if (health > 0)
        {
            return;
        }

        Debug.Log("Enemy Killed!");

        //If enemy died, add to player score and energy.
        playerStatus.Score += scoreBonus;
        playerStatus.Energy += energyBonus;

        //If enemy died due to crashing, deal damage to the player.
        if (hasCrash)
        {
            playerStatus.Health -= 2;
        }

        GameObject.Destroy(gameObject);
    }
}
