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
    public int Score = 0;

    public int ScoreToSizeUp = 1;
    [SerializeField]
    public int[] ScoreToSizes;
    public ChichenSize chichenSize = ChichenSize.tiny;
    public Sprite[] SizeSprites;
    public void GetScore(int Score)
    {
        this.Score = this.Score + Score;
        ScoreToSizeUp -= Score;
        if (ScoreToSizeUp < 0 && chichenSize < ChichenSize.SuperPuperMegaCHICKEN)
        {
            ChangeSize();
            ScoreToSizeUp = ScoreToSizes[(int)chichenSize] - Score;
        }
    }
    public void ChangeSize()
    {
        Transform transform = GetComponent<Transform>();
        float nowscale = 0;
        if (chichenSize == ChichenSize.tiny)
            nowscale = 1.2f;
        else if (chichenSize == ChichenSize.small)
            nowscale = 1.5f;
        else nowscale = 20f;
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
