using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile_Default : MissileController
{
    private PlayerStatus playerStatus;
    protected PlayerWeapons playerWeapons; 


    protected override void Awake()
    {
        base.Awake();

        playerStatus = player.GetComponent<PlayerStatus>();
        playerWeapons = player.GetComponent<PlayerWeapons>();
    }

    protected override void MissileHit(Transform target)
    {
        if (target == null)
        {
            return;
        }

        if (gameObject.CompareTag("EnemyMissile"))
        {
            //Debug.Log("Missile hit player!");
            target.GetComponent<PlayerStatus>().ReceiveDamage(Damage);
            GameObject.Destroy(gameObject);
        }

        if (gameObject.CompareTag("PlayerMissile"))
        {
            Debug.Log("Missile hit enemy!");
            playerStatus.Energy += playerWeapons.BulletCharge;
            target.GetComponent<EnemyStatus>().ReceiveDamage(Damage);
            GameObject.Destroy(gameObject);
        }
    }
}
