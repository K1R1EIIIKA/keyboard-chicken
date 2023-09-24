using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject[] crumbWithMass;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            GameObject Enemy;
            BaseCrumb baseCrumb = hitInfo.gameObject.GetComponent<BaseCrumb>();
            Enemy = Instantiate(crumbWithMass[Random.Range(0, crumbWithMass.Length)],new Vector2(baseCrumb.transform.position.x, baseCrumb.transform.position.y), Quaternion.identity);
            Enemy = Instantiate(crumbWithMass[Random.Range(0, crumbWithMass.Length)], new Vector2(baseCrumb.transform.position.x, baseCrumb.transform.position.y), Quaternion.identity);
            Enemy = Instantiate(crumbWithMass[Random.Range(0, crumbWithMass.Length)], new Vector2(baseCrumb.transform.position.x, baseCrumb.transform.position.y), Quaternion.identity);
            Destroy(Enemy, 6f);
            baseCrumb.GetHit();
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }
            
    }
}
