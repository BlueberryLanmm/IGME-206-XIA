using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossController : MonoBehaviour
{
    [Header("Movement Properties")]
    [SerializeField]
    private float startSpeed;
    [SerializeField]
    private float stopTime;

    private Vector2 position;
    private Vector2 velocity;


    [Header("Weapon Types")]
    [SerializeField, Tooltip("Add attached fire types to the list.")]
    private List<EnemyFires> fireTypes;


    private void Start()
    {
        position = transform.position;
        velocity = startSpeed * transform.up;
    }

    #region Movement
    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        if (velocity.sqrMagnitude < 0.05f)
        {
            velocity = Vector2.zero;
        }
        else
        {
            //Decelerate within a given stop time.
            velocity -=
                ((Vector2)transform.up *
                (startSpeed * Time.deltaTime / stopTime));
        }

        position += velocity * Time.deltaTime;
        transform.position = position;
    }
    #endregion
}
