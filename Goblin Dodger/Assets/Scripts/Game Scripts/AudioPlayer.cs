using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Attacks SFX")]
    [SerializeField] AudioClip arrowFireClip;
    [SerializeField] [Range(0f, 1f)] float arrowVolume = 1f;
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVolume = 1f;

    [Header("Enemy SFX")]
    [SerializeField] AudioClip enemyDeathClip;
    [SerializeField] [Range(0f ,1f)] float enemyDeathVolume = 1f;

    public void PlayArrowClip()
    {
        PlayClip(arrowFireClip, arrowVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    public void PlayEnemyDeathClip()
    {
        PlayClip(enemyDeathClip, enemyDeathVolume);
    }

    private void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
