// This script is for general controls inside a level
// It controls Gameover and levelClear, might add music control in the future
// It should be attached to a empty object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneralControl : MonoBehaviour
{
    // Pop-up Messages
    public GameObject GameOverMessage;
    public GameObject LevelClearMessage;
    public GameObject pauseMenu;
    public GameObject tutorialMessage;

    // Player
    public GameObject playerBoat;

    public bool showTutorial;
    bool gameOn;

    void Start()
    {
        gameOn = true;
        if (showTutorial)
        {
            tutorialMessage.SetActive(true);
            PauseGame();
        }
    }

    public void GameOver()
    {
        if (gameOn)
        {
            // Turn off Player Health & Control
            playerBoat.GetComponent<HealthManager>().playerHealthOff();
            playerBoat.GetComponent<PlayerController>().playerControlOff();
            // Show Game Over
            GameOverMessage.SetActive(true);
            gameOn = false;
        }
    }

    public void LevelClear()
    {
        if (gameOn)
        {
            // Turn off Player Health & Control
            playerBoat.GetComponent<HealthManager>().playerHealthOff();
            playerBoat.GetComponent<PlayerController>().playerControlOff();
            // Show Level Clear
            LevelClearMessage.SetActive(true);
            gameOn = false;
        }
    }

    public void PauseGame()
    {
        // Turn off Player Control
        playerBoat.GetComponent<PlayerController>().playerControlOff();
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
    }

    public void ResumeGame()
    {
        // Turn on Player Control
        playerBoat.GetComponent<PlayerController>().playerControlOn();
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }
}
