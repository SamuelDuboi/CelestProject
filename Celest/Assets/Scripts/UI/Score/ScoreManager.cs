using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);

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
        GameState.score += scoreToAdd;
    }

    public int DisplayScore()
    {
        return GameState.score;
    }
}
