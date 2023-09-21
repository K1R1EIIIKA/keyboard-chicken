using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chicken_Grow : MonoBehaviour
{
    public float grow;
    public float foodAmount;

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