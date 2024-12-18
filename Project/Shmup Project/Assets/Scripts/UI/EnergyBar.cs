using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    private float originalHeight;
    [SerializeField]
    private float currentHeight;
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
        currentHeight = 0;
    }

    private void Update()
    {
        //Update the length of the bar according to player status.
        float ratio = playerStatus.Energy / playerStatus.MaxEnergy;
        float refIndex = 0.1f;

        currentHeight = Mathf.Lerp(currentHeight, ratio * originalHeight, refIndex);

        rectTransform.sizeDelta = new Vector2(rectTransform.rect.width, currentHeight);

        //Blink when energy is full.
        Blink(ratio > 0.95f);
    }

    private void Blink(bool isBlinking)
    {
        Color bright = new Color(0f, 0.7f, 1f, 1f);
        Color normal = new Color(0.5f, 0.5f, 0.5f, 1);
        Color dark = new Color(0.2f, 0.2f, 0.2f, 1);
        float blinkDuration = 0.5f;

        if (isBlinking)
        {
            blinkTimer += Time.deltaTime;

            if (blinkTimer > blinkDuration)
            {
                blinkTimer *= -1f;
            }

            Color targetColor = Color.Lerp(
                dark, bright,
                Mathf.Abs(blinkTimer / blinkDuration));

            image.color = Color.Lerp(image.color, targetColor, 0.1f);
        }
        else
        {
            image.color = Color.Lerp(image.color, normal, 0.1f);
        }
    }
}
