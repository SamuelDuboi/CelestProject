using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private ScoreHandler scoreHandler;
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }
        else { Destroy(gameObject); }
    }
    private void Start()
    {
        EventHandler.instance.OnScoreUp += ChangeScore;
    }

    public void ChangeScore(int scoreToAdd)
    {
        scoreHandler.score += scoreToAdd;
    }

    public int DisplayScore()
    {
        return scoreHandler.score;
    }
}
