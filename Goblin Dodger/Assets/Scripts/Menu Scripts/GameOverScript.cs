using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScript : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] TextMeshProUGUI finalScore;

    [Header("Background")]
    [SerializeField] EnemySpawner enemySpawner;
    ScoreKeeper scoreKeeper;
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    void Start()
    {
        enemySpawner.StartSpawning();
        finalScore.text = scoreKeeper.GetCurrentScore().ToString("000000000");
    }

}
