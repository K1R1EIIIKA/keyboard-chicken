using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotMove : MonoBehaviour
{
    public GameObject[] crumb;
    public GameObject[] crumbWithMass;
    private float randomY;
    Vector2 whereToSpawn;
    public float spawnDelay;
    public float nextSpawn = 0.0f;
    public int cost = 3;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            GameObject Enemy;
           
            for (int i = 0; i < Random.Range(1, cost); i++)
            {
                    nextSpawn = Time.time + spawnDelay;
                    randomY = Random.Range(-4.5f, 4.5f);
                    whereToSpawn = new Vector2(transform.position.x, randomY);
                    Enemy = Instantiate(crumb[Random.Range(0, crumb.Length)], whereToSpawn, Quaternion.identity);
                    

                Destroy(Enemy, 6f);
                
                
                
            }
        }
    }
}