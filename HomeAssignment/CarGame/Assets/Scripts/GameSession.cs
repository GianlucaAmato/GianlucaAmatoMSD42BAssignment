﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int score = 0;

    void Awake()
    {
        SetUpSingleton();
    }

    private void Update()
    {
        PointCheck();
    }

    private void SetUpSingleton()
    {
        int numberOfGameSessions = FindObjectsOfType<GameSession>().Length;

        if (numberOfGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void AddToScore(int scoreValue)
    {
        score += scoreValue;
    }

    public void ResetGame()
    {
        Destroy(gameObject); 
    }

    public void PointCheck()
    {
        if (score >= 100)
        {
            Destroy(gameObject);
            FindObjectOfType<Level>().PlayerWins();
        }
    }

}
