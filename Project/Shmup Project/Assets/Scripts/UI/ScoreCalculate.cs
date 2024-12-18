using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculate : MonoBehaviour
{
    private float currentScore;
    private float newScore;

    private Text scoreText;

    private PlayerStatus playerStatus;


    private void Awake()
    {
        scoreText = GetComponent<Text>();
        playerStatus = 
            GameObject.FindGameObjectWithTag("Player").
            GetComponent<PlayerStatus>();
    }

    private void Start()
    {
        currentScore = 0;
        newScore = 0;
    }

    private void Update()
    {
        UpdateScore();
    }

    //Update the score smoothly using lerp.
    private void UpdateScore()
    {
        newScore = playerStatus.Score;

        currentScore = Mathf.Lerp(currentScore, newScore, 0.01f);

        scoreText.text = (Mathf.RoundToInt(currentScore)).ToString();
    }
}
