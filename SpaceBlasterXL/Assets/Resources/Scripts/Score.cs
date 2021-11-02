using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int currentScore;

    public Text scoreText;


    private void FixedUpdate()
    {
        scoreText.text = currentScore.ToString();
    }

    public void IncreaseScore(int points)
    {
        currentScore += points;
    }
}
