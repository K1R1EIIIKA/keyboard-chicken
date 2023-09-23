using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrumbCreator : MonoBehaviour
{
    public GameObject[] crumbs;
    public GameObject[] crumbWithMass;
    public int crumbToUse = 2;
    private float randomY;
    Vector2 whereToSpawn;
    public float spawnDelay;
    public float nextSpawn = 0.0f;
    public int crumbToSwawnAmount = 3;
    public int coefficient = 3;
    private int _goodOrEvil;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            GameObject Enemy;
           
            for (int i = 0; i < Random.Range(1, crumbToSwawnAmount); i++)
            {



                    nextSpawn = Time.time + spawnDelay;
                    randomY = Random.Range(-4.5f, 4.5f);
                if (Random.Range(1, 11) < coefficient)
                {
                        whereToSpawn = new Vector2(transform.position.x, randomY);
                        Enemy = Instantiate(crumbs[Random.Range(0, crumbs.Length)], whereToSpawn, Quaternion.identity);
                }
                else
                {
                    whereToSpawn = new Vector2(transform.position.x, randomY);
                    Enemy = Instantiate(crumbWithMass[Random.Range(0, crumbWithMass.Length)], whereToSpawn, Quaternion.identity);
                }



                Destroy(Enemy, 6f);
                
                
                
            }
        }
    }
}