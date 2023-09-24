using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private float AnimationSpeed = 1;
    [SerializeField] private float DamageDelay = 0;
    [SerializeField] private BoxCollider2D damageCollider;
    private Chicken chicken;
    private bool playerInside = false;
    [SerializeField] private AnimationClip animationClip;
    [SerializeField] private Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip ButtonFallSound;//ok
    IEnumerator method()
    {
        yield return new WaitForSeconds(DamageDelay);
        source.PlayOneShot(ButtonFallSound);
        if (playerInside)
        {
            Debug.Log("Chicken.GetHit()");
            chicken.GetHit();
        }

        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (chicken == null)
                chicken = other.gameObject.GetComponent<Chicken>();
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }
    private void Start()
    {
        StartCoroutine(method());
        Destroy(gameObject, DamageDelay+0.1f);
    }
}