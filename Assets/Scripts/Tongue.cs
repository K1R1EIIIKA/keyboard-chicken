using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.EventSystems.EventTrigger;

public class Tongue : MonoBehaviour
{

    [SerializeField] private AudioSource TongueSound;
    public Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.enabled = true;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.name);
        BaseCrumb crumb = other.GetComponent<BaseCrumb>();
        Chicken chicken = GetComponentInParent<Chicken>();
        //Enemy enemy=other.GetComponent<Enemy>();
        if (crumb!=null && chicken != null)
        {
            chicken.GetScore(crumb.GetScore());
            crumb.GetHit();
            PlayTongueSound();
        }
        else if(
            //enemy != null &&
           chicken != null)
        {

        }
    }
    public void Enable()
    {
        gameObject.SetActive(true);
    }
    public void Disable()
    {
        gameObject.SetActive(false);
    }
    public void Shoot()
    {
        Enable();
       // PlayAnimation();
        //wait for secs then Disable();

    }
    void PlayTongueSound()
    {
        if(!TongueSound.isPlaying)
            TongueSound.Play();
    }
}
