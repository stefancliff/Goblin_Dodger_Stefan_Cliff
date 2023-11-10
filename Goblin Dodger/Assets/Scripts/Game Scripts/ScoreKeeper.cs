using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int currentScore;
    static ScoreKeeper instance;

    void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
    }

    void Start()
    {
        ResetScore();
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public void ModifyScore(int amount)
    {
        currentScore += amount;

        Mathf.Clamp(currentScore, 0, int.MaxValue);
        Debug.Log(GetCurrentScore());
    }

    public void ResetScore()
    {
        currentScore = 0;
    }
}
