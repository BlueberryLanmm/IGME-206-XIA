using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    private float speed;
    private float scale;
    private float brightness;

    private Vector2 position;
    private Vector2 velocity;
    private Vector2 direction;

    private SpriteRenderer spriteRenderer;

    private float camButton;
    private Camera camera;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        camera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        scale = Random.Range(0.01f, 0.1f);
        speed = Random.Range(0.1f, 0.4f);
        brightness = Random.Range(0f, 1f);

        spriteRenderer.color = new Color(brightness, brightness, brightness, 1f);
        transform.localScale = new Vector2(scale, scale);
        position = transform.position;
        direction = transform.up;
        velocity = direction * speed;        

        camButton = -camera.orthographicSize - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < camButton)
        {
            GameObject.Destroy(gameObject);
        }

        ApplyMovement();
    }

    private void ApplyMovement()
    {
        position += velocity * Time.deltaTime;
        transform.position = position;
    }
}
