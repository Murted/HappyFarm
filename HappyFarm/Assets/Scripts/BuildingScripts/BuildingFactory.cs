using UnityEngine;

public class BuildingFactory
{
    public Building CreateBuilding(BuildingType buildingType, SpawnZone spawnZone)
    {
        BuildingConfig buildingData = BuildingDataProvider.Instance.GetBuildingData(buildingType);
        if (buildingData != null)
        {
            GameObject buildingObject = Object.Instantiate(buildingData.buildingPrefab);
            Building building = buildingObject.GetComponent<Building>();
            building.Initialize(spawnZone, buildingData);

            return building;
        }

        return null;
    }

    public Building CreateLoadedBuilding(BuildingType buildingType, SpawnZone spawnZone, int buildingLevel)
    {
        BuildingConfig buildingData = BuildingDataProvider.Instance.GetBuildingData(buildingType);
        if (buildingData != null)
        {
            GameObject buildingObject = Object.Instantiate(buildingData.buildingPrefab);
            Building building = buildingObject.GetComponent<Building>();
            building.Initialize(spawnZone, buildingData);
            var getBuildingConfig = BuildingDataProvider.Instance.GetBuildingData(buildingType);

            return building;
        }

        return null;
    }
}
