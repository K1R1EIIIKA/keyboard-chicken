using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private float AnimationSpeed=1;
    [SerializeField] private float DamageDelay=0;
    [SerializeField] private BoxCollider2D damageCollider;
    [SerializeField] private Chicken chicken;
    private bool playerInside = false;
    private Animator animator;
    IEnumerator method()
    {
        yield return new WaitForSeconds(DamageDelay);
        if(playerInside)
        {
            chicken.GetHit();
        }
        Destroy(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    private void Start()
    {
        animator = GetComponent<Animator>();
        StartAnimation();
        StartCoroutine(method());
    }
    public void StartAnimation()
    {
        animator.SetBool("IsRunning", true);
    }

    // И чтобы остановить анимацию "Run":
    public void StopAnimation()
    {
        animator.SetBool("IsRunning", false);
    }
}
