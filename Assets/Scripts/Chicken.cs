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
    public int score=0;
    private  GameController gameController=new GameController();
    public int ScoreToSizeUp = 1;
    [SerializeField]
    public int[] ScoreToSizes;
    public int ScoreToNextLvl=999;
    [SerializeField]
    public float[] ChickenScalers;
    public ChichenSize chichenSize = ChichenSize.tiny;
    public Sprite[] SizeSprites;
    void Awake()
    {
        ScoreToSizeUp = ScoreToSizes[0];
    }
    public void GetScore(int Score)
    {
        score += Score;
        ScoreUI.instance.SetScoreText(score);
        ScoreToSizeUp -= Score;
        if (ScoreToSizeUp < 0 && chichenSize < ChichenSize.SuperPuperMegaCHICKEN)
        {
            ChangeSize();
            ScoreToSizeUp = ScoreToSizes[(int)chichenSize] - Score;
        }
        if (Score >= ScoreToNextLvl)
        {
            gameController.LoadNextLevel();
        }
    }
    public void ChangeSize()
    {
        //PlaySizeUpAnimation();
        Transform transform = GetComponent<Transform>();
        float nowscale = ChickenScalers[(int)chichenSize];
        transform.localScale = new Vector3(nowscale, nowscale, nowscale);
        GetComponent<SpriteRenderer>().sprite = SizeSprites[(int)chichenSize];
        chichenSize++;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            GetScore(1);
    }
}
