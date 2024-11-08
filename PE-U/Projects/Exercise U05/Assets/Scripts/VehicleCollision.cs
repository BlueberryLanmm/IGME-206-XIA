using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCollision : MonoBehaviour
{
    private float collideRadius = 0.6f;
    [SerializeField]
    private int collisionCount = 0;

    private SpriteRenderer spriteRenderer;

    public float CollideRadius
    {
        get { return collideRadius; }
    }

    //Count how many obstacle is the vehicle colliding with.
    public int CollisionCount
    {
        get { return collisionCount; }

        set { collisionCount = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        InCollision();
    }

    private void InCollision()
    {
        //Change the vehicle color when there is at least one collision.
        if (CollisionCount > 0)
        {
            spriteRenderer.color = Color.red;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
