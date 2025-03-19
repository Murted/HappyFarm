public class PurchaseData
{
    public BuildingType BuildingType { get; set; }
    public int LocationIndex { get; set; }

    public PurchaseData(BuildingType buildingType, int location)
    {
        BuildingType = buildingType;
        LocationIndex = location;
    }
}
