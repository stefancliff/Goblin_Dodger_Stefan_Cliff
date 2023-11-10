using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WavesConfigSO> wavesConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    WavesConfigSO currentWave;
    [SerializeField] bool isLooping = true;
    

    public void StartSpawning()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do 
        {
            foreach(WavesConfigSO wave in wavesConfigs)
            {
                currentWave = wave;

                for(int i = 0; i < currentWave.GetEnemyCount(); i++) 
                {
                    Instantiate(currentWave.GetEnemyPrefab(i), 
                                currentWave.GetStartingWaypoint().position, 
                                Quaternion.Euler(0, 0, 180), 
                                transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);

                
            }
        } while (isLooping);
        
    }

    public WavesConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
