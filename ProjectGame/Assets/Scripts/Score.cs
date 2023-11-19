using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Score : MonoBehaviour
{
    public static Score score;
    public int scoreNum;
    public string scoreText = "0";
    private void Awake()
    {
        score = this;
    }
    public void ScoreUpdate(int ponto)
    {
        scoreNum = scoreNum + ponto;

        scoreText = scoreNum.ToString();

    }
}
