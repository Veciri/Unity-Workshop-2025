using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New watering can item", menuName = "Assets/Items/New watering can item")]
public class WateringCan : ToolClass
{
    public override void UseItem()
    {
        PlantManager plantManager = FindAnyObjectByType<PlantManager>();
        plantManager.WaterPlant();
    }
}
