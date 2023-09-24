using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public GameObject[] crumbWithMass;
    public Rigidbody2D rb;
    private int[] crumbs = new int[3];

    // Start is called before the first frame update
    void FixedUpdate()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy"))
        {
            GameObject Enemy;
            BaseCrumb baseCrumb = hitInfo.gameObject.GetComponent<BaseCrumb>();

            if (baseCrumb.EnemyOrNo == 0)
            {
                crumbs = new int[] { 0, 1, 2 };
            }
            else if (baseCrumb.EnemyOrNo == 2)
            {
                crumbs = new int[] { 3, 4, 5 };
            }
            else if (baseCrumb.EnemyOrNo == 4)
            {
                crumbs = new int[] { 6, 7, 8 };
            }
            else if (baseCrumb.EnemyOrNo == 6)
            {
                crumbs = new int[] { 9, 10, 11 };
            }
            else if (baseCrumb.EnemyOrNo == 9)
            {
                crumbs = new int[] { 12, 13, 14 };
            }

            Enemy = Instantiate(crumbWithMass[crumbs[2]], new Vector2(baseCrumb.transform.position.x, baseCrumb.transform.position.y), Quaternion.identity);
            BaseCrumb baseCrumb1 = Enemy.GetComponent<BaseCrumb>();
            baseCrumb1.EnemyOrNo = -1;
            Destroy(Enemy, 6f);
            Enemy = Instantiate(crumbWithMass[crumbs[1]], new Vector2(baseCrumb.transform.position.x, baseCrumb.transform.position.y), Quaternion.identity);
            BaseCrumb baseCrumb2 = Enemy.GetComponent<BaseCrumb>();
            baseCrumb2.EnemyOrNo = -3;
            Destroy(Enemy, 6f);
            Enemy = Instantiate(crumbWithMass[crumbs[0]], new Vector2(baseCrumb.transform.position.x, baseCrumb.transform.position.y), Quaternion.identity);
            BaseCrumb baseCrumb3 = Enemy.GetComponent<BaseCrumb>();
            baseCrumb3.EnemyOrNo = -2;
            Destroy(Enemy, 6f);

            baseCrumb.GetHit();
            Debug.Log(hitInfo.name);
            Destroy(gameObject);
        }
    }
}
