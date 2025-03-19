using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public static BuildingManager Instance;

    public BuildingInfoUI buildingInfoUI;
    public BuildingZoneUI buildingZoneUI;
    public List<BuildableLocation> buildableLocations;
    public BuildingFactory buildingFactory;
    public SpawnZone spawnZone;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        for(int i = 0; i < buildableLocations.Count; i++)
        {
            buildableLocations[i].zoneIndex = i;
        }

        buildingFactory = new BuildingFactory();
        FinanceManager.OnPurchaseCompleted += BuildNewBuilding;
        FinanceManager.OnUpgradeCompleted += UpgradeBuilding;
    }

    public void BuildNewBuilding(PurchaseData purchaseData)
    {
        Building buildingObject = buildingFactory.CreateBuilding(purchaseData.BuildingType, SpawnZone.Instance);

        buildingObject.transform.position = buildableLocations[purchaseData.LocationIndex].gameObject.transform.position;
        buildableLocations[purchaseData.LocationIndex].currentBuilding = buildingObject;
        buildableLocations[purchaseData.LocationIndex].gameObject.SetActive(false);
    }

    public void UpgradeBuilding(Building building)
    {
        building.UpgradeBuilding();
    }

    public void OnBuildingClicked(Building building)
    {
        buildingInfoUI.ShowBuildingInfo(building);
    }

    public void OnBuildingZoneClicked(BuildableLocation buildableLocation)
    {
        buildingZoneUI.ShowZoneUI(buildableLocation.zoneIndex);
    }

    public List<SerializableBuilding> GetBuildableLocationsData()
    {
        List<SerializableBuilding> data = new List<SerializableBuilding>();

        foreach (var location in buildableLocations)
        {
            if (location.currentBuilding != null)
            {
                data.Add(new SerializableBuilding(location.currentBuilding, location.zoneIndex));
            }
        }

        return data;
    }

    public void LoadBuildings(List<SerializableBuilding> buildingData)
    {
        foreach (var serializableBuilding in buildingData)
        {
            Building building = buildingFactory.CreateLoadedBuilding(serializableBuilding.buildingType, spawnZone, serializableBuilding.buildingLevel);

            BuildableLocation location = buildableLocations[serializableBuilding.zoneIndex];
            building.transform.position = location.gameObject.transform.position;

            location.currentBuilding = building;
            location.gameObject.SetActive(false);
        }
    }

    public void OnDestroy()
    {
        FinanceManager.OnPurchaseCompleted -= BuildNewBuilding;
    }
}
