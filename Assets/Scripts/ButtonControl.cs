// This script is for all button controls (switch scene, open menu, etc.)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public GameObject quitConform;
    string levelOne = "Level1";
    string levelTwo = "Level2";
    string levelThree = "Level3";
    string MainMenu = "MainMenu";

    // Level Switching
    public void LoadLevelOne()
    {
        SceneManager.LoadScene(levelOne);
    }
    public void LoadLevelTwo()
    {
        SceneManager.LoadScene(levelTwo);
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(MainMenu);
    }

    // Quit Game
    public void QuitButton()
    {
        quitConform.SetActive(true);
    }
    public void DoQuitGame()
    {
        Application.Quit();
    }
    public void CloseQuitConfirm()
    {
        quitConform.SetActive(false);
    }
}
