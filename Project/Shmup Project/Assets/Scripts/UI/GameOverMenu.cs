using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverMenu : MonoBehaviour
{
    private RectTransform winMenu;
    private Text scoreText;

    private RectTransform loseMenu;

    private PlayerStatus playerStatus;


    private void Awake()
    {
        winMenu = transform.GetChild(0).GetComponent<RectTransform>();
        scoreText = winMenu.GetComponentInChildren<Text>();

        loseMenu = transform.GetChild(1).GetComponent<RectTransform>();

        playerStatus = 
            GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerStatus>();
    }

    private void Start()
    {
        //Disable the UI menus at the beginning.
        winMenu.gameObject.SetActive(false);
        loseMenu.gameObject.SetActive(false);
    }

    private void Update()
    {
        //If player health down to 0, enable lost menu.
        if (playerStatus.Health <= 0)
        {
            loseMenu.gameObject.SetActive(true);
        }

        //If player killed the boss, enable win menu.
        if (playerStatus.HasWon)
        {
            winMenu.gameObject.SetActive(true);
            scoreText.text = ((int)(playerStatus.Score)).ToString();
        }
    }
}
