using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    
    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    [Header("Intro UI")]
    [SerializeField] Canvas introCanvas;

    [Header("Game UI")]
    [SerializeField] Canvas gameUI;

    [Header("Enemy Spawner")]
    [SerializeField] EnemySpawner enemySpawner;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        gameUI.enabled = false;
        introCanvas.enabled = true;
    }

    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    void Update()
    {
        healthSlider.value  = playerHealth.GetHealth();
        scoreText.text      = scoreKeeper.GetCurrentScore().ToString("000000000");
    }

    public void HideIntroPanel()
    {
        gameUI.enabled      = true;
        introCanvas.enabled = false;
        enemySpawner.StartSpawning();
    }
}
