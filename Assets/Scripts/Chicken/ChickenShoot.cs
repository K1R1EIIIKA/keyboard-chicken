using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ChickenShoot : MonoBehaviour
{
    [SerializeField] private float shootPushback = 1f;
    [SerializeField] private float shootCooldown = 0.5f;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip SpitSound;//ok
    [SerializeField] private Chicken chicken;
    
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Rigidbody2D _rb;
    private bool _isCooldown;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !_isCooldown)
        { 
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        float scale = chicken.ChickenScalers[(int)chicken.chickenSize];
        bullet.transform.localScale = new Vector3(4 *scale, 3 * scale, scale) * 1.5f;
        
        source.PlayOneShot(SpitSound);
        PushBack();
        PlayShootAnimation();
         _isCooldown = true;
        StartCoroutine(ShootCooldown());
    }

    private void PlayShootAnimation()
    {

    }

    private IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        _isCooldown = false;
    }
    void PushBack()
    {
        Vector2 pushDirection;
        if (ChickenMovement.IsLeft)
            pushDirection = Vector2.right * shootPushback;
        else
            pushDirection = Vector2.left * shootPushback;

        if (ChickenMovement.IsMove)
            pushDirection *= 2.5f;

        _rb.AddForce(pushDirection, ForceMode2D.Impulse);
    }
}
