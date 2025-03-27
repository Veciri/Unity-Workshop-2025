using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New item", menuName = "Assets/Items/New item")]
public class ItemClass : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;

    public virtual void UseItem()
    {
        Debug.Log("using item");
    }

    public void DropItem()
    {
        FindAnyObjectByType<DroppingManager>().CreateItemDrop(this);
    }
}
