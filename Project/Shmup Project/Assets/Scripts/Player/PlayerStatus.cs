using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Basic Properties")]
    private int health = 0;
    private float score = 0;
    private float energy = 0;
    private bool isInvincible = false;
    private bool hasWon = false;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private float maxEnergy;

    private SpriteRenderer spriteRenderer;
    private Animator animator;


    #region Properties
    public int Health
    {
        get { return health; }

        set { health = value; }
    }

    public float Score
    { 
        get { return score; } 
        
        set { score = value; } 
    }

    public float Energy
    {
        get { return energy; }

        set { energy = value; }
    }

    public int MaxHealth
    {
        get { return maxHealth; }
    }

    public float MaxEnergy
    {
        get { return maxEnergy; }
    }

    public bool HasWon
    { 
        get { return hasWon; } 

        set {  hasWon = value; }
    }
    #endregion


    private void Awake()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        energy = maxEnergy;
        score = 0;

        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }

        if (health > 0)
        {
            score += Time.deltaTime * 10f;
        }

        GameOver();
    }

    public void ReceiveDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            StartCoroutine(Blink());
        }
    }

    private void GameOver()
    {
        //Stop the time when game is over.
        if (health <= 0)
        {
            Time.timeScale = 0f;

            if (!isInvincible)
            {
                StartCoroutine(Blink());
            }
        }

        if (hasWon)
        {
            Time.timeScale = 0f;
            isInvincible = true;
            animator.enabled = true;
        }
    }

    private IEnumerator Blink()
    {
        isInvincible = true;

        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = Color.clear;

            yield return new WaitForSecondsRealtime(0.2f);

            spriteRenderer.color = Color.white;

            yield return new WaitForSecondsRealtime(0.2f);
        }

        if (health <= 0)
        {
            GameObject.Destroy(gameObject);
        }

        isInvincible = false;
    }
}
