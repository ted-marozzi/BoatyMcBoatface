// This script is for all button controls (switch scene, open menu, etc.)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    string levelOne = "Level1";
    string levelTwo = "Level2";
    string levelThree = "Level3";
    string MainMenu = "MainMenu";

    public void LoadLevelOne()
    {
        SceneManager.LoadScene(levelOne);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
