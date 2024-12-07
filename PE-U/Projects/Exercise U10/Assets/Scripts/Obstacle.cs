using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float radius;

    private Transform transform;
    private SpriteRenderer spriteRenderer;

    public float Radius
    {
        get { return radius; }

        set { radius = value; }
    }


    private void Awake()
    {
        transform = GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        radius = spriteRenderer.bounds.extents.x;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
