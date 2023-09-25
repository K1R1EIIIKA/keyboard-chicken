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
        // �������� ��������� SpriteRenderer � �������, �� ������� ��������� �����������
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = See;
        if (spriteRenderer.enabled)
        {
            Time.timeScale = 0;
        }
    }

    private void Update()
    {
        // ���������, ���� �� ������ ������� (� ������ ������, ������)
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            // ���� ����������� ������ (��������), �� ��������� ��� � ���������� ������� ������
            if (spriteRenderer.enabled)
            {
                spriteRenderer.enabled = false;
                if (!See)
                {
                    Time.timeScale = 1;
                }
                
                Destroy(this.gameObject);
            }
            // �����, ���� ����������� ���������, �� �������� ���
            else
            {
                spriteRenderer.enabled = true;
            }
        }
    }
}
