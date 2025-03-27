using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> inventory = new List<InventoryItem>();

    public int inventorySize = 15;

    [Header("References")]
    public GameObject itemPrefab;
    public Transform inventoryTransform;

    private void Start()
    {
        CreateInventorySlots();
        TestAddingItems();
        inventoryTransform.gameObject.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            inventoryTransform.gameObject.SetActive(!inventoryTransform.gameObject.activeSelf);
        }
    }
    /*public void HandleInventoryOpen(InputAction.CallbackContext callbackContext)
    {
        inventoryTransform.gameObject.SetActive(!inventoryTransform.gameObject.activeSelf);
    }*/

    private void CreateInventorySlots()
    {
        for (int i = 0; i < inventorySize; i++)
        {
            InventoryItem item = Instantiate(itemPrefab, inventoryTransform).GetComponent<InventoryItem>();
            item.Set(null, 0);
            item.OnDragItem += OnDragItem;
            item.OnBeginDragItem += OnBeginDragItem;
            item.OnEndDragItem += OnEndDragItem;
            item.OnDropItem += OnDropItem;
            inventory.Add(item);
        }
    }

    public int currentItemBeingDragged = -1;
 
    private void OnDragItem(InventoryItem itemPassed)
    {
    }

    private void OnBeginDragItem(InventoryItem itemPassed)
    {
        int index = inventory.FindIndex(i => i.item == itemPassed.item);
        currentItemBeingDragged = index;
    }

    private void OnEndDragItem(InventoryItem itemPassed)
    {
        currentItemBeingDragged = -1;
    }

    private void OnDropItem(InventoryItem itemPassed)
    {
        if(currentItemBeingDragged != -1)
        {
            //temp
            ItemClass itemRef = itemPassed.item;
            int quantity = itemPassed.quantity;

            InventoryItem originalDraggedItem = inventory[currentItemBeingDragged];
            itemPassed.Set(originalDraggedItem.item, originalDraggedItem.quantity);

            originalDraggedItem.Set(itemRef, quantity);
        }
    }

    public void AddItemToInventory(ItemClass itemRef, int quantity)
    {
        //TO-DO check if there's space

        int index = inventory.FindIndex(i => i.item == null);
        inventory[index].Set(itemRef, quantity);
    }

    #region testing
    public ItemClass itemExample;
    public ItemClass itemExample2;
    public ItemClass itemExample3;
    private void TestAddingItems()
    {
        int quantity = 3;
        AddItemToInventory(itemExample, quantity);
        AddItemToInventory(itemExample2, 1);
        AddItemToInventory(itemExample3, 1);
    }
    #endregion
}
