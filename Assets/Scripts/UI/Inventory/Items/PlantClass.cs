using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New plant item", menuName = "Assets/Items/New plant item")]
public class PlantClass : ItemClass
{
    public List<Sprite> growingSprites;

    public int GetTimeToGrow()
    {
        return growingSprites.Count - 1;
    }
}
