using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private bool _onOrOff = true;
    public bool See = true;


    private void Start()
    {
        // Получаем компонент SpriteRenderer у объекта, на котором находится изображение
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = See;
        if (spriteRenderer.enabled)
        {
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        // Проверяем, была ли нажата клавиша (в данном случае, пробел)
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Если изображение видимо (включено), то выключаем его и уничтожаем текущий объект
            if (spriteRenderer.enabled)
            {
                spriteRenderer.enabled = false;
                if (!See)
                {
                    Time.timeScale = 1;
                }
                
                Destroy(this.gameObject);
            }
            // Иначе, если изображение выключено, то включаем его
            else
            {
                spriteRenderer.enabled = true;
            }
        }
    }
}
