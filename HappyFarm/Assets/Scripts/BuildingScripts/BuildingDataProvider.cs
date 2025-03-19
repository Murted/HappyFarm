using System.Collections.Generic;
using UnityEngine;

public class BuildingDataProvider : MonoBehaviour
{
    public static BuildingDataProvider Instance;

    public List<BuildingConfig> buildingDataList;
    private Dictionary<BuildingType, BuildingConfig> buildingDataDictionary;

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

        buildingDataDictionary = new Dictionary<BuildingType, BuildingConfig>();
        foreach (BuildingConfig data in buildingDataList)
        {
            buildingDataDictionary.Add(data.type, data);
        }
    }

    public BuildingConfig GetBuildingData(BuildingType buildingType)
    {
        if (buildingDataDictionary.ContainsKey(buildingType))
        {
            return buildingDataDictionary[buildingType];
        }
        else
        {
            return null;
        }
    }
}
