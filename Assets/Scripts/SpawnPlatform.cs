using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    public GameObject Platformss;
    public float nextSpawn = 3f;
    private float randomY;
    public float spawnDelay = 1;
    Vector2 whereToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            GameObject Platform;

            nextSpawn = Time.time + spawnDelay;
            randomY = Random.Range(-4.5f, 4.5f);
                whereToSpawn = new Vector2(transform.position.x, randomY);
            Platform  = Instantiate(Platformss,whereToSpawn, Quaternion.identity);
               

                Destroy(Platform, 6f);
            }
        }

    }

