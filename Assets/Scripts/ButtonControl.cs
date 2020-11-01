// This script is for all button controls (switch scene, open menu, etc.)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public GameObject quitConform;
    public GameObject levelsMenu;
    public GameObject creditsMenu;
    public GameObject tutorialMessage;
    public GameObject LevelControl;

    string levelOne = "Level1";
    string levelTwo = "Level2";
    string levelThree = "Level3";
    string MainMenu = "MainMenu";

    // Pause and Resume
    public void PauseGame()
    {
        LevelControl.GetComponent<LevelGeneralControl>().PauseGame();
    }
    public void ResumeGame()
    {
        LevelControl.GetComponent<LevelGeneralControl>().ResumeGame();
    }

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

    // Levels Menu
    public void ShowLevelsMenu()
    {
        levelsMenu.SetActive(true);
    }
    public void CloseLevelsMenu()
    {
        levelsMenu.SetActive(false);
    }

    // Credits Menu
    public void ShowCreditsMenu()
    {
        creditsMenu.SetActive(true);
    }
    public void CloseCreditsMenu()
    {
        creditsMenu.SetActive(false);
    }

    // Other Messages
    public void CloseTutorial()
    {
        tutorialMessage.SetActive(false);
        ResumeGame();
    }
}
