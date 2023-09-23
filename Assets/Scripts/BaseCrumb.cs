using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCrumb : MonoBehaviour
{
    public int Score = 0;
    [SerializeField]
    private float Size = 1;
    public void GetHit()
    {
        Destroy(this.gameObject);
    }
    public int GetScore() => Score; 


}
