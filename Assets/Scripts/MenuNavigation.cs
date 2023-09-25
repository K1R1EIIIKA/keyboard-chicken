using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void Level1()
    {
        Time.timeScale = 1;
        LevelLogic.IsWon = false;
        SceneManager.LoadScene("Level");
    }

    public void MainMenu()
    {
        LevelLogic.IsWon = false;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        LevelLogic.IsWon = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}