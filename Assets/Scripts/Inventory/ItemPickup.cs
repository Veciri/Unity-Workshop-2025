using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ItemClass itemClass;
    public void Set(ItemClass itemClass)
    {
        this.itemClass = itemClass;
        GetComponent<SpriteRenderer>().sprite = itemClass.itemIcon;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PlayerController>()!=null)
        {
            FindAnyObjectByType<InventoryManager>().AddItemToInventory(itemClass, 1);
            Destroy(gameObject);
        }
    }
}
