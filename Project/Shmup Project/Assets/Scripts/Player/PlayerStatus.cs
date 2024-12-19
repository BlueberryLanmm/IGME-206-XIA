using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Basic Properties")]
    private int health = 0;
    private float score = 0;
    private float energy = 0;
    private int invincibleIndex = 0;
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

    public int InvincibleIndex
    {
        get { return invincibleIndex; }

        set { invincibleIndex = value; }
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
        invincibleIndex = 0;

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
        if (invincibleIndex == 0)
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

            if (invincibleIndex == 0)
            {
                StartCoroutine(Blink());
            }
        }

        if (hasWon)
        {
            Time.timeScale = 0f;
            invincibleIndex += 1;
            animator.enabled = true;
        }
    }

    private IEnumerator Blink()
    {
        invincibleIndex += 1;

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

        invincibleIndex -= 1;
    }
}
