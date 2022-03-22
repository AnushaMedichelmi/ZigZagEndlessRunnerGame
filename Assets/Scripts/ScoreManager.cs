using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    int score;
     public Text scoreText;

    public void ScoreCalculator(int scoreValue)
    {
        score = score + scoreValue;
        scoreText.text = score.ToString();       
        Debug.Log("Score :" +score);
    }
}
