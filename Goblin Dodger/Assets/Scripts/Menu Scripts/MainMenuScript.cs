using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;

    void Awake()
    {
        enemySpawner.StartSpawning();
    }

}
