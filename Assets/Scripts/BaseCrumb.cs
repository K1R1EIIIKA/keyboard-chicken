using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCrumb : MonoBehaviour
{
    [SerializeField]
    private float Speed = 0.1f;
    public int Score = 0;
    [SerializeField]
    private float Size = 1;
    public void GetHit()
    { 
         Destroy(this.gameObject);
    }
    void FixedUpdate()
    {
        transform.position = new Vector2(transform.position.x - Speed * Time.fixedDeltaTime, transform.position.y);
    }
    public int GetScore() => Score;

   
}
