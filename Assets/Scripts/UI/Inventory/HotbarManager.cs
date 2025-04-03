using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotbarManager : MonoBehaviour
{
    public List<InventoryItem> hotbarSlots = new List<InventoryItem>();
    public InventoryManager inventoryManager;
    public Transform hotbarTransform;

    public int hotbarSize = 5;

    private void Start()
    {
        CreateInventorySlots();
    }
    private void CreateInventorySlots()
    {
        for (int i = 0; i < hotbarSize; i++)
        {
            InventoryItem item = Instantiate(inventoryManager.itemPrefab, hotbarTransform).GetComponent<InventoryItem>();
            item.Set(null, 0);
            hotbarSlots.Add(item);
            item.OnClickItem += OnClickItem;
        }
    }

    private void Update()
    {
        for(int i=0; i<hotbarSize; i++)
        {
            InventoryItem originalItem = inventoryManager.inventory[i];
            hotbarSlots[i].Set(originalItem.item, originalItem.quantity);
        }
    }

    public int currentItemBeingSelected = -1;

    private void OnClickItem(InventoryItem itemPassed)
    {
        int index = hotbarSlots.FindIndex(i => i.item == itemPassed.item);
        if (currentItemBeingSelected == -1)
        {
            //NOTHING CURRENTLY SELECTED
            currentItemBeingSelected = index;
            itemPassed.transform.GetChild(3).gameObject.SetActive(true);
            MouseFollower.instance.ChangeCursor(itemPassed.item.itemIcon);
        }
        else
        {
            if (index == currentItemBeingSelected)
            {
                //DESELECT CURRENT ITEM
                itemPassed.transform.GetChild(3).gameObject.SetActive(false);
                currentItemBeingSelected = -1;
                MouseFollower.instance.ChangeCursor(null);
                return;
            }

            //CLICKING ON A DIFFERENT ITEM
            //selecting new item? not working fully
            hotbarSlots[currentItemBeingSelected].transform.GetChild(3).gameObject.SetActive(false);
            currentItemBeingSelected = index;
            itemPassed.transform.GetChild(3).gameObject.SetActive(true);
            MouseFollower.instance.ChangeCursor(itemPassed.item.itemIcon);

        }
    }

}
