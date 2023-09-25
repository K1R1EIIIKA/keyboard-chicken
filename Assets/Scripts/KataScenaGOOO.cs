using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KataScenaGOOO : MonoBehaviour
{
    public GameObject[] Picture;
    public float startDelay = 2.0f; // �������� ����� ������� ����� �����������
    public float spawnDelay = 1.0f; // �������� ����� ������ �����������
    private bool index = true;
    private int currentIndex = 0;
    private float nextSpawnTime = 0.0f;

    void Start()
    {
        if (index)
        {
            Time.timeScale = 0;
            // �������� ������ �����������
            Picture[currentIndex].SetActive(true);
            nextSpawnTime = Time.realtimeSinceStartup + startDelay;
        }
    }

    void Update()
    {
        if (!index) return; // ���� ������ ����� false, ������� �� Update

        if (Time.realtimeSinceStartup >= nextSpawnTime && index)
        {
            // ��������� ������� �����������
            Picture[currentIndex].SetActive(false);

            // ���������, ���� �� ��������� �����������
            if (currentIndex == Picture.Length - 1)
            {
                Time.timeScale = 1;
                index = false;
                Destroy(this.gameObject);
            }
            else
            {
                // ����������� ������
                currentIndex++;

                // �������� ��������� �����������
                Picture[currentIndex].SetActive(true);

                // ������������� ����� ��������� �����
                nextSpawnTime = Time.realtimeSinceStartup + spawnDelay;
            }
        }
    }
}
