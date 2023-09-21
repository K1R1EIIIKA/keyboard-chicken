using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotDelete : MonoBehaviour
{

    public float speed = 0.1f;
    int direction = -1;
    private float[] speeder = { 1.1f, 1.3f, 1.2f, 1.4f, 1.5f, 1.6f, 1.7f, 1.8f, 1.9f };
    void FixedUpdate()
    {
        if (direction == -1) {
            direction = Random.Range(0, 3);
        }
        if (direction == 0)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
        }
        else if (direction == 1)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y - speeder[Random.Range(0,7)] * Time.fixedDeltaTime);
        }
        else if (direction == 2)
        {
            transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y + speeder[Random.Range(0, 7)] * Time.fixedDeltaTime);
        }

    }

   
}
