using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    public Tilemap tilemap;

    public HotbarManager hotbar;

    private void Start()
    {
        hotbar = GetComponent<HotbarManager>();
    }

    private void Update()
    {
        if(hotbar.currentItemBeingSelected != -1)
        {
            Vector3Int tilePos = GetMouseToTile();
            //print(tilePos);
            if(Input.GetMouseButtonDown(0))
            {
                print("inside");
                hotbar.hotbarSlots[hotbar.currentItemBeingSelected].item.UseItem();
            }
            if(Input.GetKeyDown(KeyCode.Q))
            {
                hotbar.hotbarSlots[hotbar.currentItemBeingSelected].item.DropItem();
                //TO-DO actually get rid of the item from the inventory
            }
        }
    }
    public Vector3Int GetMouseToTile()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3Int tilePos = tilemap.WorldToCell(worldPos);
        return tilePos;
    }
}
