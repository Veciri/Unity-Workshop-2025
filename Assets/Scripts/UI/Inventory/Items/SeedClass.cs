using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New seed item", menuName = "Assets/Items/New seed item")]
public class SeedClass : ItemClass
{
    public PlantClass plantRef;
    public int yield = 1;
    //public bool isRenewable;

    public override void UseItem()
    {
        Debug.Log("Use plant");
        PlantManager plantManager = FindAnyObjectByType<PlantManager>();
        plantManager.AddNewPlant(this);

    }
}
