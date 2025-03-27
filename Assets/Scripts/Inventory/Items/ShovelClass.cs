using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New shovel item", menuName = "Assets/Items/New shovel item")]
public class ShovelClass : ToolClass
{
    public override void UseItem()
    {
        PlantManager plantManager = FindAnyObjectByType<PlantManager>();
        plantManager.HarvestItem();
    }
}
