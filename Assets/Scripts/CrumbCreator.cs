using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbCreator : MonoBehaviour
{
    public GameObject[] Crumbs;
    public int CrumbTypes=2;
    private float randomY;
    Vector2 whereToSpawn;
    public float spawnDelay=0.8f;
    public float nextSpawn = 0.0f;
    public int CrumbsToSpawnAmount = 3;
    
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            for (int i = 0; i < Random.Range(1, CrumbsToSpawnAmount); i++)
            {
                nextSpawn = Time.time + spawnDelay;
                randomY = Random.Range(-4.5f, 4.5f);
                whereToSpawn = new Vector2(transform.position.x, randomY);
                GameObject Crumb = Instantiate(Crumbs[Random.Range(0, CrumbTypes)], whereToSpawn, Quaternion.identity);
                Destroy(Crumb, 6f);
            }
        }
    }
}