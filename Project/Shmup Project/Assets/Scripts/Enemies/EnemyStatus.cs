using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [Header("Basic Properties")]
    private int health;

    [SerializeField]
    private bool isBoss;
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int scoreBonus;
    [SerializeField]
    private float energyBonus;

    private bool hasCrash;

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
    #endregion


    private void Awake()
    {
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
        DeathCheck(hasCrash);
    }

    public void ReceiveDamage(int damage)
    {
        health -= damage;
        StartCoroutine(Blink());
    }

    public void ReceiveDamage(int damage, bool hasCrash)
    {
        if (isBoss)
        {
            return;
        }

        health -= damage;
        this.hasCrash = hasCrash;
        StartCoroutine(Blink());
    }

    public void DeathCheck(bool hasCrash)
    {
        if (health > 0)
        {
            return;
        }

        //If enemy died due to crashing, deal damage to the player.
        if (hasCrash)
        {
            playerStatus.ReceiveDamage(2);
        }
        else
        {
            //If enemy died, add to player score and energy.
            playerStatus.Score += scoreBonus;
            playerStatus.Energy += energyBonus;
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
