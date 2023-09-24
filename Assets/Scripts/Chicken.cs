using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Chicken : MonoBehaviour
{
    public enum ChichenSize
    {
        tiny = 0,
        small,
        average,
        SuperPuperMegaCHICKEN
    }
    public int score = 0;
    public int ScoreToSizeUp = 1;
    [SerializeField]
    public int[] ScoreToSizes;
    public int ScoreToNextLvl = 999;
    [SerializeField]
    public float[] ChickenScalers;
    public ChichenSize chichenSize = ChichenSize.tiny;
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
        if (ScoreToSizeUp < 1 )
        {
            if (chichenSize < ChichenSize.SuperPuperMegaCHICKEN)
            {
                IncreaseSize();
                gameController.LoadNextLevel();
                ScoreToSizeUp = ScoreToSizes[(int)chichenSize] - score;
            }
            else UWin();
        }
        SetScoreUI();
    }

    private void UWin()
    {
        //PlayEngGameScene();
    }

    public int GetChickenSize() => (int)chichenSize;
    private void SetScoreUI()
    {
        ScoreUI.instance.SetScoreText(score);
    }

    public void IncreaseSize()
    {
        chichenSize++;
        //PlayAnimation(SizeUp);
        PlaySound(ChickenSizeUpSound);
        ChangeScale();
        ChangeSprite();
    }
    public void DecreaseSize()
    {
        chichenSize--;
        //PlayAnimation(SizeDown);
        PlaySound(ChickenSizeDownSound);
        ChangeScale();
        ChangeSprite();
    }
    void ChangeScale()
    {
        Transform transform = GetComponent<Transform>();
        Debug.Log("Chickensize:"+ (int)chichenSize);
        Debug.Log("nowscale:" + ChickenScalers[(int)chichenSize]);
        float nowscale = ChickenScalers[(int)chichenSize];
        transform.localScale = new Vector3(nowscale, nowscale, nowscale);
    }
    void ChangeSprite()
    {
        GetComponent<SpriteRenderer>().sprite = SizeSprites[(int)chichenSize];
    }
    void PlaySound(AudioClip clip)
    {
        soundSource.PlayOneShot(clip);
    }

    public void GetHit()
    {
        Debug.Log("ChickenGetHit()");
        if (GetChickenSize() > 0)
        {   //PlayAnimation(GetHit);
            PlaySound(ChickenGetHitSound);
            DecreaseSize();
        }
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("ChickenTriggerEnter()");
        EnemyButton enemyButton = collider.gameObject.GetComponent<EnemyButton>();
        if(enemyButton != null)
        {
            GetHit();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            GetScore(1);
    }
}
