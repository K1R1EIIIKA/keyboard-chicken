using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject winCanvas;

    private bool _isPaused;

    public static bool IsWon;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseLogic();

        if (IsWon)
            Win();
    }

    private void Win()
    {
        Time.timeScale = 0;
        winCanvas.SetActive(true);
    }

    private void PauseLogic()
    {
        _isPaused = !_isPaused;

        if (_isPaused)
            Pause();
        else
            Unpause();
    }

    private void Pause()
    {
        pauseCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    public void Unpause()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}