using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public static ScoreUI instance;
    public Text scoreText;
    public string previousString;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText.text = previousString + "0";
    }

    public void SetScoreText(int Score)
    {
        scoreText.text = previousString + Score.ToString();
    }
}