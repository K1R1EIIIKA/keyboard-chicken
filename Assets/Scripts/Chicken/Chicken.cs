using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms.Impl;

public class Chicken : MonoBehaviour
{
    public enum ChickenSize
    {
        Tiny = 0,
        Small,
        Average,
        SuperPuperMegaCHICKEN
    }

    public enum ChickenAge
    {
        First = 0,
        Second,
        Third,
        Fourth
    }

    public int score = 0;
    public int ScoreToSizeUp = 1;
    [SerializeField] public int[] ScoreToSizes;
    public int ScoreToNextLvl = 999;
    [SerializeField] public float[] ChickenScalers;
    public ChickenSize chickenSize = ChickenSize.Tiny;
    public ChickenAge chickenAge = ChickenAge.First;
    public Sprite[] SizeSprites;
    private Animator animator;
    [SerializeField]
    private LevelLogic
     levelLogic;
    [SerializeField] private GameController gameController;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip ChickenGetHitSound;
    [SerializeField] private AudioClip ChickenJumpSound;//ok
    [SerializeField] private AudioClip ChickenSizeUpSound; //ok
    [SerializeField] private AudioClip ChickenSizeDownSound; //ok
    [SerializeField] private AudioClip ChickenStepSound;
    [SerializeField] private AudioClip ChickenFlySound;
    [SerializeField] private AudioClip ChickenTongueSound; //ok

    void Awake()
    {
        ScoreToSizeUp = ScoreToSizes[0];
        ChangeScale();
        animator = gameObject.GetComponent<Animator>();
    }
    public void PlayJumpSound()
    {
        PlaySound(ChickenJumpSound);
    }
    public void GetScore(int Score)
    {
        animator.SetTrigger("Eat");

        score += Score;
        ScoreToSizeUp -= Score;
        PlaySound(ChickenTongueSound);
        if (ScoreToSizeUp < 1)
        {
            if (chickenSize < ChickenSize.SuperPuperMegaCHICKEN && chickenAge <= ChickenAge.Fourth)
            {
                IncreaseSize();
                ScoreToSizeUp = ScoreToSizes[(int)chickenSize] - score;
            }
            else if (chickenSize == ChickenSize.SuperPuperMegaCHICKEN && chickenAge < ChickenAge.Fourth)
            {
                gameController.LoadNextLevel();
                chickenSize = ChickenSize.Tiny;
                score = 0;
                IncreaseAge();
                ChangeScale();
                ScoreToSizeUp = ScoreToSizes[(int)chickenSize] - score;
            }
            else if (chickenSize == ChickenSize.SuperPuperMegaCHICKEN && chickenAge == ChickenAge.Fourth)
            {
                levelLogic.IsWon = true;
            }
        }

        SetScoreUI();
    }

    public int GetChickenSize() => (int)chickenSize;

    public int GetChickenAge() => (int)chickenAge;

    private void SetScoreUI()
    {
        ScoreUI.instance.SetScoreText(score);
    }

    public void IncreaseSize()
    {
        chickenSize++;
        PlaySound(ChickenSizeUpSound);
        ChangeScale();
    }

    public void IncreaseAge()
    {
        chickenAge++;
        animator.SetInteger("ChickLevel", (int)chickenAge);
        ChangeSprite();
    }

    public void DecreaseSize()
    {
        chickenSize--;
        //PlayAnimation(SizeDown);
        PlaySound(ChickenSizeDownSound);
        ChangeScale();
    }

    void ChangeScale()
    {
        Transform transform = GetComponent<Transform>();
        float nowscale = ChickenScalers[(int)chickenSize];
        transform.localScale = new Vector3(nowscale, nowscale, nowscale);
    }

    void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = SizeSprites[(int)chickenAge];
    }

    void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    public void GetHit()
    {
        Debug.Log("ChickenGetHit()");
        if (GetChickenSize() > 0)
        {
            animator.SetTrigger("Hit");
            PlaySound(ChickenGetHitSound);
            DecreaseSize();
            score = ScoreToSizes[(int)chickenSize];
            ScoreToSizeUp = ScoreToSizes[(int)chickenSize + 1] - ScoreToSizes[(int)chickenSize];
            SetScoreUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("ChickenTriggerEnter2D()");
        if (collider.CompareTag("Enemy") || collider.CompareTag("EnemySmall"))
        {
            GetHit();
            if (collider.CompareTag("Enemy"))
            {
                GetHit();
            }
            BaseCrumb baseCrumb = collider.gameObject.GetComponent<BaseCrumb>();
            if(baseCrumb!=null)
                baseCrumb.GetHit();
        }
    }

    // private void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.M))
    //         GetScore(5);
    // }
}