using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //Singleton pattern
    public static GameController instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public Text scoreText;
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;

    public int lastPlayerToScore = 2;

    public void UpdateScore(int player)
    {
        lastPlayerToScore = player;

        if (player == 1) scorePlayer1++; else scorePlayer2++;
        scoreText.text = scorePlayer1.ToString() + "  -  " + scorePlayer2.ToString();
    }
}
