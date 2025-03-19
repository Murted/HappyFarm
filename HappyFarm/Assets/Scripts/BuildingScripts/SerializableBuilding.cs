[System.Serializable]
public class SerializableBuilding
{
    public BuildingType buildingType;
    public int buildingLevel;
    public int zoneIndex;
    public int buildingUpgradeCost;

    public SerializableBuilding(Building building, int zoneIndex)
    {
        this.buildingType = building.GetBuildingType();
        this.buildingLevel = building.buildingLevel;
        this.zoneIndex = zoneIndex;
        this.buildingUpgradeCost = building.buildingUpgradeCost;
    }
}