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

    [SerializeField] private GameController gameController;
    [SerializeField] private AudioSource soundSource;
    [SerializeField] private AudioClip ChickenGetHitSound;
    [SerializeField] private AudioClip ChickenSizeUpSound;
    [SerializeField] private AudioClip ChickenSizeDownSound;
    [SerializeField] private AudioClip ChickenStepSound;
    [SerializeField] private AudioClip ChickenSpitSound;

    void Awake()
    {
        ScoreToSizeUp = ScoreToSizes[0];
    }

    public void GetScore(int Score)
    {
        score += Score;
        ScoreToSizeUp -= Score;
        if (ScoreToSizeUp < 1)
        {
            if (chickenSize < ChickenSize.SuperPuperMegaCHICKEN)
            {
                IncreaseSize();
                gameController.LoadNextLevel();
                ScoreToSizeUp = ScoreToSizes[(int)chickenSize] - score;
            }
            else UWin();
        }

        SetScoreUI();
    }

    private void UWin()
    {
        //PlayEngGameScene();
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
        //PlayAnimation(SizeUp);
        PlaySound(ChickenSizeUpSound);
        ChangeScale();
        ChangeSprite();
    }

    public void DecreaseSize()
    {
        chickenSize--;
        //PlayAnimation(SizeDown);
        PlaySound(ChickenSizeDownSound);
        ChangeScale();
        ChangeSprite();
    }

    void ChangeScale()
    {
        Transform transform = GetComponent<Transform>();
        Debug.Log("Chickensize:" + (int)chickenSize);
        Debug.Log("nowscale:" + ChickenScalers[(int)chickenSize]);
        float nowscale = ChickenScalers[(int)chickenSize];
        transform.localScale = new Vector3(nowscale, nowscale, nowscale);
    }

    void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = SizeSprites[(int)chickenSize];
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
            //PlayAnimation(GetHit);
            PlaySound(ChickenGetHitSound);
            DecreaseSize();
            score = ScoreToSizes[(int)chickenSize];
            ScoreToSizeUp = ScoreToSizes[(int)chickenSize + 1] - ScoreToSizes[(int)chickenSize];
            SetScoreUI();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("ChickenTriggerEnter()");
        EnemyButton enemyButton = collider.gameObject.GetComponent<EnemyButton>();
        if (enemyButton != null)
        {
            GetHit();
        }

        if (collider.CompareTag("Enemy") || collider.CompareTag("EnemySmall"))
        {
            if ((int)chickenSize == 0 && ScoreToSizeUp >= ScoreToSizes[(int)chickenSize])
            {
                ScoreToSizeUp = ScoreToSizes[(int)chickenSize];
            }

            else
            {
                if (collider.CompareTag("Enemy"))
                {
                    ScoreToSizeUp += 6;
                }
                else
                {
                    ScoreToSizeUp += 1;
                }

            }
            
            if ((int)chickenSize >= 1 &&
                (ScoreToSizeUp > ScoreToSizes[(int)chickenSize] - ScoreToSizes[(int)chickenSize - 1]))
            {
                GetHit();
            }
            
            BaseCrumb baseCrumb = collider.gameObject.GetComponent<BaseCrumb>();
            baseCrumb.GetHit();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            GetScore(1);
    }
}