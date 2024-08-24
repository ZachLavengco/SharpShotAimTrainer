using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text ScoreText;
    private int score;

    void Start()
    {
        score = 0;
    }

    public void increaseScore(int newScore)
    {
        score += newScore;
    }

    public int GetScore()
    {
        return score;
    }

    void Update()
    {
        ScoreText.text = "Score: " + score;
        StateNameController.score = "Score: " + score;
    }
}
