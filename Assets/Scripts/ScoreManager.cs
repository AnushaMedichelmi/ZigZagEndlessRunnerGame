using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoreText;

    private void Start()
    {
        //for (int i = 0; i < 10; i++)
        //{
        //    TileSpawnManager.Instance.SpawnTile();

        //}
    }
    public void ScoreUpdate(int scoreValue)
    {
        score = score + scoreValue;
        Debug.Log("Score: " + score);
        scoreText.text = score.ToString();
    }


}