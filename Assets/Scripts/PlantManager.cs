using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantManager : MonoBehaviour
{
    public TileManager tileManager;
    public Transform plantsTransform;
    public List<Plant> currentPlants = new List<Plant>();

    public GameObject plantPrefab;

    private void Start()
    {
        tileManager = GetComponent<TileManager>();
    }

    public void AddNewPlant(SeedClass seedClass)
    {
        Vector3Int pos = tileManager.GetMouseToTile();

        foreach (Plant plant in currentPlants)
        {
            if (plant.transform.position == pos)
            {
                print("Keep it, we don't want it");
                return;
            }
        }

        Plant newPlant = Instantiate(plantPrefab, plantsTransform).GetComponent<Plant>();
        newPlant.Set(seedClass);
        newPlant.transform.position = pos;
        currentPlants.Add(newPlant);
    }

    public void OnNewDay()
    {
        foreach(Plant plant in currentPlants)
        {
            if(plant.isWatered && !plant.isHarvestable)
            {
                plant.growthIndex++;
                if (plant.growthIndex == plant.seedRef.plantRef.GetTimeToGrow())
                {
                    plant.isHarvestable = true;
                }
            }
            plant.isWatered = false;
            plant.SetVisual();
        }
    }

    public void WaterPlant()
    {
        Vector3Int plantPos = tileManager.GetMouseToTile();
        foreach (Plant plant in currentPlants)
        {
            if (plant.transform.position == plantPos && !plant.isWatered)
            {
                plant.isWatered = true;
                plant.SetVisual();
                return;
            }
        }
    }

    public void HarvestItem()
    {
        Vector3Int plantPos = tileManager.GetMouseToTile();

        for(int c=0; c<currentPlants.Count; c++)
        {
            if (currentPlants[c].transform.position == plantPos && currentPlants[c].isHarvestable)
            {
                GetComponent<DroppingManager>().CreateItemDrop(currentPlants[c].seedRef.plantRef);
                currentPlants.RemoveAt(c);
                Destroy(currentPlants[c].gameObject);
            }
        }
    }
}
