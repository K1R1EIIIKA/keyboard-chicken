using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyButton : MonoBehaviour
{
    [SerializeField] private float AnimationSpeed = 1;
    [SerializeField] private float DamageDelay = 0;
    [SerializeField] private BoxCollider2D damageCollider;
    [SerializeField] private Chicken chicken;
    [SerializeField] private bool playerInside = false;
    [SerializeField] private Animator animator;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip ButtonFallSound; //ok

    IEnumerator method()
    {
        yield return new WaitForSeconds(DamageDelay);
        //Debug.Log("method Started");

        if (playerInside)
        {
            chicken.GetHit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("playerInside");
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

    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(DamageDelay - 0.5f);
        source.PlayOneShot(ButtonFallSound);
    }

    private void Start()
    {
        StartCoroutine(method());
        if (ButtonFallSound == null) Debug.LogWarning("Missing ButtonFallSound sound");
        else StartCoroutine(PlaySound());
        animator.speed = AnimationSpeed;
        Destroy(gameObject, DamageDelay + 0.1f);
    }
}