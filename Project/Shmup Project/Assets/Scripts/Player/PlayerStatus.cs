using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [Header("Basic Properties")]
    private int health = 0;
    private int score = 0;
    private float energy = 0;

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private float maxEnergy;


    #region Properties
    public int Health
    {
        get { return health; }

        set { health = value; }
    }

    public int Score
    { 
        get { return score; } 
        
        set { score = value; } 
    }

    public float Energy
    {
        get { return energy; }

        set { energy = value; }
    }
    #endregion


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
