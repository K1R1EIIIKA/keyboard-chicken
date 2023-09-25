using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Animations;
using UnityEngine;

public class LevelLogic : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject winCanvas;
    private bool index = true;


    private bool _isPaused;

    public bool IsWon=false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseLogic();

        if (IsWon)
        {
            if (index)
            {
                SomeMethod();
                index = false;
            }
            
            if (SomeMethod2())
            {
                Win();
            }
        }
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

    private bool SomeMethod2()
    {
        GameObject autroScenaSpawnObject = GameObject.Find("AutroScenaSpawn");

        // Проверяем, найден ли объект
        if (autroScenaSpawnObject != null)
        {
            // Получаем компонент "AutroSCENA" на объекте "AutroScenaSpawn"
            AutroSCENA autroScenaComponent = autroScenaSpawnObject.GetComponent<AutroSCENA>();

            // Проверяем, найден ли компонент
            if (autroScenaComponent != null)
            {
                if(autroScenaComponent.someBool2 == true)
                {
                    return true;
                }
            }
        }
        return false;
        
    }
        private void SomeMethod()
    {
        // Находим объект "AutroScenaSpawn" в сцене
        GameObject autroScenaSpawnObject = GameObject.Find("AutroScenaSpawn");

        // Проверяем, найден ли объект
        if (autroScenaSpawnObject != null)
        {
            // Получаем компонент "AutroSCENA" на объекте "AutroScenaSpawn"
            AutroSCENA autroScenaComponent = autroScenaSpawnObject.GetComponent<AutroSCENA>();

            // Проверяем, найден ли компонент
            if (autroScenaComponent != null)
            {
                // Устанавливаем значение переменной someBool
                autroScenaComponent.someBool = true;
            }
        }
    }

}


