using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenShoot : MonoBehaviour
{
    [SerializeField] private float shootPushback = 1f;
    [SerializeField] private float shootCooldown = 0.5f;
    
    private Rigidbody2D _rb;
    private bool _isCooldown;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !_isCooldown)
            Shoot();
    }

    private void Shoot()
    {
        Vector2 pushDirection;
        if (ChickenMovement.IsLeft)
            pushDirection = Vector2.right * shootPushback;
        else
            pushDirection = Vector2.left * shootPushback;

        if (ChickenMovement.IsMove)
            pushDirection *= 2.5f;
        
        _rb.AddForce(pushDirection, ForceMode2D.Impulse);
        
        _isCooldown = true;
        StartCoroutine(ShootCooldown());
    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        _isCooldown = false;
    }
    public void OnTriggerEnter(Collider other)
    {
        BaseCrumb crumb = other.GetComponent<BaseCrumb>();
        if(crumb != null)
        {
            crumb.GetHit();
            //GetScore(crumb.GetScore());
        }
    }
}
