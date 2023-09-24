using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{    
    public static int LevelNumber = 0;

    private void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level 1":
                LevelNumber = 0;
                break;
            case "Level 2":
                LevelNumber = 1;
                break;
            case "Level 3":
                LevelNumber = 2;
                break;
            case "Level 4":
                LevelNumber = 3;
                break;
        }
    }

    public void Level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }
    
    public void Level2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 3");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
