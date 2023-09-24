using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbMovement : MonoBehaviour
{
    public float speed = 0.1f;
    int direction = -1;
    private float[] speeder = { 1.1f, 1.3f, 1.2f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f };

    void FixedUpdate()
    {
        BaseCrumb baseCrumb = gameObject.GetComponent<BaseCrumb>();

        if (direction == -1)
        {
            direction = Random.Range(0, 3);
        }
        if (baseCrumb.EnemyOrNo == -3 || (direction == 0 && baseCrumb.EnemyOrNo != -2 && baseCrumb.EnemyOrNo != -1))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
        }
        else if (baseCrumb.EnemyOrNo == -2 || (direction == 1 && baseCrumb.EnemyOrNo != -3 && baseCrumb.EnemyOrNo != -1))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y - speeder[Random.Range(0, 7)] * Time.fixedDeltaTime);
        }
        else if (baseCrumb.EnemyOrNo == -1 || (direction == 2 && baseCrumb.EnemyOrNo != -2 && baseCrumb.EnemyOrNo != -3))
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y + speeder[Random.Range(0, 7)] * Time.fixedDeltaTime);
        }
    }
}
