using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float downSpeed = 2f;
    [SerializeField] private float flyForce = 4.5f;
    [SerializeField] private float bounceForce = 8f;
    [SerializeField] private float velocityNormalizeSpeed = 0.02f;
    [SerializeField] private Animator animator;

    private Rigidbody2D _rb;

    public static bool IsLeft;
    public static bool IsMove;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
        
        if (Input.GetKeyDown(KeyCode.K))
            Jump();
        
        if (_rb.velocity.y < -1.0f * downSpeed)
            _rb.velocity = new Vector2(_rb.velocity.x, -downSpeed);

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        
        if (_rb.velocity.x != 0)
        {
            if (!IsMove)
                _rb.velocity =
                    Vector2.MoveTowards(_rb.velocity, new Vector2(0, _rb.velocity.y), velocityNormalizeSpeed);
            else
                _rb.velocity = 
                    Vector2.MoveTowards(_rb.velocity, new Vector2(0, _rb.velocity.y), velocityNormalizeSpeed * 2);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            animator.SetBool("IsGround", true);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.transform.CompareTag("Ground"))
        {
            animator.SetBool("IsGround", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("BounceGround"))
        {
            _rb.AddForce(Vector2.up * bounceForce, ForceMode2D.Impulse);
            animator.SetTrigger("Hit");
        }
    }

    
    private void Move()
    {
        float axisHorizontal = Input.GetAxisRaw("Horizontal");

        if (axisHorizontal < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            IsLeft = true;
            IsMove = true;
        }
        else if (axisHorizontal > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            IsLeft = false;
            IsMove = true;
        }
        else
        {
            IsMove = false;
        }
        
        Vector3 direction = new Vector3(axisHorizontal, 0, 0).normalized;
        transform.position += direction * (Time.deltaTime * speed);
    }

    private void Jump()
    {
        _rb.velocity = Vector2.zero;
        _rb.AddForce(new Vector2(0, flyForce), ForceMode2D.Impulse);
        Chicken chicken = GetComponent<Chicken>();
        chicken.PlayJumpSound();

    }
}
