using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private bool isBackground = false;

    private float originalHeight;
    private float currentHeight;
    private float newHeight;

    [SerializeField]
    float updateTimer = 0;
    float blinkTimer = 0;

    private RectTransform rectTransform;
    private Image image;

    private PlayerStatus playerStatus;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        image = GetComponent<Image>();

        playerStatus = 
            GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerStatus>();
    }

    private void Start()
    {
        originalHeight = rectTransform.rect.height;
        currentHeight = originalHeight;
    }

    private void Update()
    {
        if (isBackground)
        {
            UpdateBackground();
        }
        else
        {
            UpdateHeight();
        }    
    }

    private void UpdateHeight()
    {
        updateTimer -= Time.deltaTime;

        //The current health percentage
        float ratio = (float)playerStatus.Health / playerStatus.MaxHealth;
        newHeight = ratio * originalHeight;

        currentHeight = Mathf.Lerp(currentHeight, ratio * originalHeight, 0.1f);

        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, currentHeight);

        Blink(ratio < 0.25f);
    }

    private void UpdateBackground()
    {
        updateTimer -= Time.deltaTime;

        //The current health percentage
        float ratio = (float)playerStatus.Health / playerStatus.MaxHealth;
        newHeight = ratio * originalHeight;

        if (Mathf.Abs(newHeight - currentHeight) < 0.5f)
        {
            if (isBackground)
            {
                updateTimer = 0.5f;
            }
        }

        if (updateTimer < 0)
        {
            currentHeight = Mathf.Lerp(currentHeight, ratio * originalHeight, 0.01f);

            rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, currentHeight);
        }
    }

    //Blinking red effect when hp is low.
    private void Blink(bool isBlinking)
    {
        if (isBackground)
        {
            return;
        }

        Color normal = Color.white;
        Color red = Color.red;
        float blinkDuration = 0.5f;

        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;

            if (blinkTimer > blinkDuration)
            {
                blinkTimer *= -1f;
            }

            Color targetColor = Color.Lerp(
                normal, red,
                Mathf.Abs(blinkTimer / blinkDuration));

            image.color = Color.Lerp(image.color, targetColor, 0.1f);

        }
        else
        {
            image.color = Color.Lerp(image.color, normal, 0.1f);
        }
    }
}
