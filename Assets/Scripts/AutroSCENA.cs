using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutroSCENA : MonoBehaviour
{

    public GameObject[] Picture;
    public float startDelay = 2.0f; // Задержка перед началом смены изображений
    public float spawnDelay = 1.0f; // Задержка между сменой изображений
    private bool index = false;
    private int currentIndex = 0;
    private float nextSpawnTime = 0.0f;
    public bool someBool = false;
    public bool someBool2 = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (someBool)
        {
            Time.timeScale = 0;
            // Включаем первое изображение
            Picture[currentIndex].SetActive(true);
            nextSpawnTime = Time.realtimeSinceStartup + startDelay;
            someBool = false;
            index = true;
        }
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
                someBool2 = true;
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
