using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public Color wateredColour;

    public SeedClass seedRef;
    private SpriteRenderer spriteRenderer;
    public int growthIndex;
    public bool isWatered = false;
    public bool isHarvestable = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    internal void Set(SeedClass seedClass)
    {
        seedRef = seedClass;
        SetVisual();
    }

    public void SetVisual()
    {
        spriteRenderer.sprite = seedRef.plantRef.growingSprites[growthIndex];
        if (isWatered)
        {
            spriteRenderer.color = wateredColour;
        }
        else
        {
            spriteRenderer.color = Color.white;
        }
    }
}
