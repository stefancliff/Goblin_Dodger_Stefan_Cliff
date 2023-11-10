using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed      = 10f;
    [SerializeField] float projectileLifeTime   = 5f;

    [Header("AI")]
    [SerializeField] bool useAI; 
    [SerializeField] float baseProjectileFiringRate   = 1f;
    [SerializeField] float ProjectileRateVariance     = 0.2f;
    [SerializeField] float ProjectileFireRateMinimum  = 0.2f;
    
    [HideInInspector] public bool isFiring;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useAI)
        {
            isFiring = true;
        }
    }


    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
        
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            
            Rigidbody2D rigidbody2D = instance.GetComponent<Rigidbody2D>();
            
            if(rigidbody2D != null)
            {
                rigidbody2D.velocity = transform.up * projectileSpeed;
            }

            Destroy(instance, projectileLifeTime);

            float timeToNextProjectile = UnityEngine.Random.Range(baseProjectileFiringRate - ProjectileRateVariance, baseProjectileFiringRate + ProjectileRateVariance);
            
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, ProjectileFireRateMinimum, float.MaxValue);

            audioPlayer.PlayArrowClip();

            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }
}
