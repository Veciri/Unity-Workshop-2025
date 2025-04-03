using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler, IPointerClickHandler
{
    public ItemClass item;
    public int quantity;

    public event Action<InventoryItem> OnDragItem, OnBeginDragItem, OnEndDragItem, OnDropItem, OnClickItem;

    public void Set(ItemClass itemRef, int quantity)
    {
        this.quantity = quantity;
        item = itemRef;

        //if empty
        if (itemRef == null)
        {
            transform.GetChild(1).GetComponent<Image>().sprite = null;
            transform.GetChild(2).gameObject.SetActive(false);
        }
        else
        {
            transform.GetChild(2).gameObject.SetActive(true);
            transform.GetChild(1).GetComponent<Image>().sprite = item.itemIcon;
            transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = quantity.ToString();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //in the inventory manager, we want to store a reference to the item being dragged
        OnDragItem?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragItem?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragItem?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnDropItem?.Invoke(this);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //transform.GetChild(3).gameObject.SetActive(!transform.GetChild(3).gameObject.activeSelf);
        OnClickItem?.Invoke(this);
    }

    //you want to check if where you stopped is in an inventory slot
    //if it is, exchange positions (so set original dragging to where you stopped, and viceversa)
}
