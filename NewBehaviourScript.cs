using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Chicken_Movement : MonoBehaviour
{
    public float speed;

    private float _axisX;
    private float _axisY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
        _axisX = Input.GetAxisRaw("Horizontal");
        _axisY = Input.GetAxisRaw("Vertical");
        
        Vector3 direction = new Vector3(_axisX,_axisY, z:0);
        
        transform.position += direction.normalized * (speed * Time.deltaTime);
    }
}
