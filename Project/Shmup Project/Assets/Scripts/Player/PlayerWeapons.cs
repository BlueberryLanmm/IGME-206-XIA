using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapons : MonoBehaviour
{
    private float bulletFireTimer;
    private float missileFireTimer;

    [Header("Gun Properties", order = 0)]
    [Header("Gun Fire", order = 1)]
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private int bulletDamage;
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
    private int missileDamage;
    [SerializeField]
    private float missileRange;
    [SerializeField]
    private float missileCooldown;
    [SerializeField]
    private float eneryCost;
    [Header("Missile Movements", order = 1)]
    [SerializeField]
    private float accelerateSpeed;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxTurnAngle;


    // Start is called before the first frame update
    void Start()
    {
        bulletFireTimer = bulletCooldown;
        missileFireTimer = missileCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        FireGuns();
        FireMissiles();
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

    private void FireMissiles()
    {

    }
}
