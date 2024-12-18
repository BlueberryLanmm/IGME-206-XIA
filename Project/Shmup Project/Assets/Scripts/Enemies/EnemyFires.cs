using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// This is a parent class for enemies' fire type.
/// </summary>
public abstract class EnemyFires : MonoBehaviour
{
    //More fields required in children classes.
    [Header("Weapon Properties")]
    [SerializeField]
    protected GameObject missile;
    [SerializeField]
    protected float fireCooldown;

    private bool isCounting = true;
    private float fireTimer;

    private void Awake()
    {

    }

    protected virtual void Start()
    {
        fireTimer = fireCooldown;
    }

    private void Update()
    {
        //Fire missile whenever a countdown is finished.
        if (isCounting)
        {
            fireTimer -= Time.deltaTime;
        }

        if (fireTimer < 0f)
        {
            fireTimer = fireCooldown;
            FireMissiles();
        }
    }

    protected abstract void FireMissiles();


    //Method to manage all fire types for bosses. Not used currently.
    public void ResetCounting(
        [Tooltip("To start or stop counting.")]bool isCounting, 
        [Tooltip("Set the ratio for countdown remains (0-1).")]float countdownRatio)
    {
        this.isCounting = isCounting;
        fireTimer = countdownRatio * fireCooldown;
    }
}
