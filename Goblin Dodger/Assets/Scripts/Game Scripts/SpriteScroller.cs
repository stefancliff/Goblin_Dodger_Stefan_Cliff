using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteScroller : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed;

    Vector2 offset;
    Material material;
    
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }


    void Update()
    {
        ScrollBackground();
    }

    void ScrollBackground()
    {
        offset = scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
