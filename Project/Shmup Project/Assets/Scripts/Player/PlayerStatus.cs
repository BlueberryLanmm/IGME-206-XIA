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

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private float maxEnergy;

    private SpriteRenderer spriteRenderer;


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
    #endregion


    private void Awake()
    {
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        health = MaxHealth;
        energy = maxEnergy;
        score = 0;
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
    }

    public void ReceiveDamage(int damage)
    {
        if (!isInvincible)
        {
            health -= damage;
            StartCoroutine(Blink());
        }
    }

    private IEnumerator Blink()
    {
        isInvincible = true;

        for (int i = 0; i < 3; i++)
        {
            spriteRenderer.color = Color.clear;

            yield return new WaitForSeconds(0.2f);

            spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(0.2f);
        }

        isInvincible = false;
    }
}
