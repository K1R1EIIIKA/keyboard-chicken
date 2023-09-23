using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip ButtonFallSound;
    [SerializeField] private AudioClip CrumbDestructionSound;
    void Awake()
    {
        instance = this;
    }
    private void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }
}
