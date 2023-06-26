using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private int Score;

    public static GameController Instan;
    public int ScoreCurrent;
    [SerializeField] private TMP_Text scoreText;

    private void Awake()
    {
        if (Instan == null)
        {
            Instan = this;
        }
    }


    public void IncreamentScore(bool isLeg)
    {
        if (isLeg)
        {
            Score += 200;
        }
        else
        {
            Score += 100;
        }

        StartCoroutine(IncreamentScore());
    }

    public void IncreamentScore(int Score)
    {
        this.Score += this.Score;
        StartCoroutine(IncreamentScore());
    }

    [SerializeField] private float Timer;

    IEnumerator IncreamentScore()
    {
        Timer = 0;

        while (ScoreCurrent != Score)
        {
            Timer += Time.deltaTime * 10;
            ScoreCurrent = Mathf.FloorToInt(Mathf.Lerp(ScoreCurrent, Score, Timer));
            scoreText.text = "Score: " + ScoreCurrent;
            yield return new WaitForSeconds(Timer / 2);
        }

        Timer = 0;
    }
}