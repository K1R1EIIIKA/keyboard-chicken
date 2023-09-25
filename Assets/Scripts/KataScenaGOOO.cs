using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KataScenaGOOO : MonoBehaviour
{
    public GameObject[] Picture;
    public float startDelay = 2.0f; // Задержка перед началом смены изображений
    public float spawnDelay = 1.0f; // Задержка между сменой изображений
    private bool index = true;
    private int currentIndex = 0;
    private float nextSpawnTime = 0.0f;

    void Start()
    {
        if (index)
        {
            Time.timeScale = 0;
            // Включаем первое изображение
            Picture[currentIndex].SetActive(true);
            nextSpawnTime = Time.realtimeSinceStartup + startDelay;
        }
    }

    void Update()
    {
        if (!index) return; // Если индекс равен false, выходим из Update

        if (Time.realtimeSinceStartup >= nextSpawnTime && index)
        {
            // Выключаем текущее изображение
            Picture[currentIndex].SetActive(false);

            // Проверяем, было ли последнее изображение
            if (currentIndex == Picture.Length - 1)
            {
                Time.timeScale = 1;
                index = false;
                Destroy(this.gameObject);
            }
            else
            {
                // Увеличиваем индекс
                currentIndex++;

                // Включаем следующее изображение
                Picture[currentIndex].SetActive(true);

                // Устанавливаем время следующей смены
                nextSpawnTime = Time.realtimeSinceStartup + spawnDelay;
            }
        }
    }
}
