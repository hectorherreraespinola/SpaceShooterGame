using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private Material material;
    public float parallaxEffectMultiplier = 2f;
    private Vector2 offset;

    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
        offset = material.mainTextureOffset;
    }

    void Update()
    {
        offset.y += Time.deltaTime / parallaxEffectMultiplier;
        material.mainTextureOffset = offset;
    }
}
