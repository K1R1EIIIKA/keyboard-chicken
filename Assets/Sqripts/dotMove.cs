using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotMove : MonoBehaviour
{

    public GameObject[] dot;
    private float randomY;
    Vector2 whereToSpawn;
    public float spawnDelay;
    float nextSpawn = 0.0f;
    public int len;
    public int cost = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    len = dot.Length;
        if (Time.time > nextSpawn)
        {
            for (int i = 0; i < Random.Range(1, cost); i++)
            {


                nextSpawn = Time.time + spawnDelay;
                randomY = Random.Range(-4.5f, 4.5f);
                whereToSpawn = new Vector2(transform.position.x, randomY);
                GameObject Enemy = Instantiate(dot[Random.Range(0, len - 1)], whereToSpawn, Quaternion.identity);
                Destroy(Enemy, 6f);
            }
        }
}
}
