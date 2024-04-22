using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
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

    public bool isPaused = false;
    public GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void BackToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
