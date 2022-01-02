using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool isGameActive = false;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    private float timeLeft = 60.0f;
    public Text timerText;

    private void Update()
    {
        UpdateTime();
    }

    public void StartGame()
    {
        isGameActive = true;
        titleScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        Cursor.visible = false;
    }

    public bool GameStatus()
    {
        return isGameActive;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        gameOverScreen.SetActive(false);
        titleScreen.SetActive(true);
    }

    public void UpdateTime()
    {
        if (isGameActive)
        {
            timeLeft -= Time.deltaTime;
            int timeLeftInt = (int)Mathf.Round(timeLeft);
            timerText.text = "Time left: " + timeLeftInt;
            if (timeLeft < 0)
            {
                GameOver();
            }
        }
    }

    public void GameOver()
    {
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
        Cursor.visible = true;
    }
}
