using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotMove : MonoBehaviour
{
    public GameObject[] dot;
    private float randomY;
    Vector2 whereToSpawn;
    public float spawnDelay;
    public float nextSpawn = 0.0f;
    public int cost = 3;
    
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            for (int i = 0; i < Random.Range(1, cost); i++)
            {
                nextSpawn = Time.time + spawnDelay;
                randomY = Random.Range(-4.5f, 4.5f);
                whereToSpawn = new Vector2(transform.position.x, randomY);
                
                GameObject Enemy = Instantiate(dot[Random.Range(0, dot.Length)], whereToSpawn, Quaternion.identity);
                Destroy(Enemy, 6f);
            }
        }
    }
}