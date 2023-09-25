using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 0.1f;

    void FixedUpdate()
    {
        // �������� ������� ���������
        transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
    }
}