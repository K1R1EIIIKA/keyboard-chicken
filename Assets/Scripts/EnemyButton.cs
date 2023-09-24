using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private float AnimationSpeed = 1;
    [SerializeField] private float DamageDelay = 0;
    [SerializeField] private BoxCollider2D damageCollider;
    [SerializeField] private Chicken chicken;
    private bool playerInside = false;
    [SerializeField] private AnimationClip animationClip;
    [SerializeField] private Animator animator;

    IEnumerator method()
    {
        yield return new WaitForSeconds(DamageDelay);
        
        if (playerInside)
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
        StartCoroutine(method());
    }
}