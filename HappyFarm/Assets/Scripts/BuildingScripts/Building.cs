using UnityEngine;
using UnityEngine.EventSystems;

public class Building : MonoBehaviour
{
    private GameObject animalPrefab;
    private SpawnZone spawnZone; 
    public int buildingLevel = 1;
    private BuildingConfig buildingConfig;
    public int buildingUpgradeCost;

    public void Initialize(SpawnZone spawnZone, BuildingConfig config)
    {
        this.buildingConfig = config;
        this.animalPrefab = config.animalPrefab;
        this.spawnZone = spawnZone;
        buildingUpgradeCost = config.upgradeCost;

        for(int i = 0;i<buildingLevel;i++)
        {
            SpawnAnimal();
        }        
    }

    public void UpgradeBuilding()
    {
        buildingLevel++;
        buildingUpgradeCost += buildingConfig.upgradeCost;

        SpawnAnimal();
    }

    public int GetBuildCost()
    {
        return buildingConfig.buildCost;
    }

    public int GetUpgradeCost()
    {
        return buildingUpgradeCost;
    }

    public string GetBuildingName()
    {
        return buildingConfig.BuildingName;
    }

    public string GetBuildingLevel()
    {
        return buildingLevel.ToString();
    }

    public BuildingType GetBuildingType()
    {
        return buildingConfig.type;
    }

    private void SpawnAnimal()
    {
        Vector3 spawnPosition = spawnZone.GetRandomPosition();

        GameObject animal = Instantiate(animalPrefab, spawnPosition, Quaternion.identity);
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        BuildingManager.Instance.OnBuildingClicked(this);
    }
}
