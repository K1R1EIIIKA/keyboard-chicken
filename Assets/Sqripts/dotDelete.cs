using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotDelete : MonoBehaviour
{

    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - speed * Time.fixedDeltaTime, transform.position.y);
    }

   
}
