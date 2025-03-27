using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingManager : MonoBehaviour
{
    public ItemPickup droppedItemPrefab;

    public void CreateItemDrop(ItemClass itemClass)
    {
        ItemPickup newItemPickup = Instantiate(droppedItemPrefab);
        newItemPickup.transform.position = GetComponent<TileManager>().GetMouseToTile() + new Vector3Int(1, 1, 0);
        newItemPickup.Set(itemClass);
    }
}
