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

    // Player
    public GameObject playerBoat;

    bool gameOn;

    void Start()
    {
        gameOn = true;
    }

    public void GameOver()
    {
        if (gameOn)
        {
            // Turn off Player Control
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
            // Turn off Player Control
            playerBoat.GetComponent<HealthManager>().playerHealthOff();
            playerBoat.GetComponent<PlayerController>().playerControlOff();
            // Show Game Over
            LevelClearMessage.SetActive(true);
            gameOn = false;
        }
    }
}
