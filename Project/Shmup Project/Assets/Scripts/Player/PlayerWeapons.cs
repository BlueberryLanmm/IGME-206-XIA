using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    private float bulletFireTimer;
    [SerializeField]
    private float missileFireTimer;

    [Header("Gun Properties", order = 0)]
    [Header("Gun Fire", order = 1)]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private float bulletCooldown;
    [SerializeField]
    private float energyCharge;
    [Header("Gun Movement", order = 1)]
    [SerializeField]
    private float bulletSpeed;

    [Header("Missile Properties", order = 0)]
    [Header("Missile Fire", order = 1)]
    [SerializeField]
    private GameObject missile;
    [SerializeField]
    private float missileCooldown;
    [SerializeField]
    private float energyCost;
    private bool isTriggered;


    private PlayerStatus status;


    #region Properties
    public bool IsTriggered
    {
        get { return isTriggered; }

        set { isTriggered = value; }
    }

    public float BulletCharge
    {
        get { return energyCharge; }
    }
    #endregion


    private void Awake()
    {
        status = GetComponent<PlayerStatus>();
    }

    // Start is called before the first frame update
    void Start()
    {
        bulletFireTimer = 3f;
        missileFireTimer = missileCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        FireGuns();
        FireMissiles(IsTriggered);
    }

    private void FireGuns()
    {
        bulletFireTimer -= Time.deltaTime;

        if (bulletFireTimer < 0f)
        {
            //Reset the fire timer.
            bulletFireTimer = bulletCooldown;

            //Instantiate the bullet to face upwards.
            GameObject.Instantiate(
                bullet,
                transform.position + transform.up,
                transform.rotation);
        }
    }

    public void FireMissiles(bool isTriggered)
    {
        missileFireTimer -= Time.deltaTime;

        //If not triggered, return and do nothing.
        if (!isTriggered)
        {
            return;
        }

        if (status.Energy >= energyCost)
        {
            if (missileFireTimer < 0f)
            {
                Debug.Log("Missile Fire!");

                //Reset the fire timer.
                missileFireTimer = missileCooldown;
                status.Energy -= energyCost;

                //Instantiate the bullet to face upwards.
                GameObject.Instantiate(
                    missile,
                    transform.position + transform.up,
                    transform.rotation);
            }
        }
    }
}
