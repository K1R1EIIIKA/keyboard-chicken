using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Grow : MonoBehaviour
{
    public float grow;
    public float foodAmount;
    public float _scaleX = 1f, _scaleY = 1f, _scaleZ = 1f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            
            foodAmount += grow;
            if (foodAmount % 1 == 0) 
            {
                 transform.localScale += new Vector3(grow,grow,grow); 
            }
        }
        if (collision.CompareTag("Enemy"))
        {
            //Checken chicken = other.GetComponent<chicken>();
           // chicken.GetHit();
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
    }
}