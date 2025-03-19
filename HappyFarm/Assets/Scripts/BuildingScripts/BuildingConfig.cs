using UnityEngine;

[CreateAssetMenu(fileName = "New Building", menuName = "Config/BuildConfig")]
public class BuildingConfig : ScriptableObject
{
    public BuildingType type;
    public string BuildingName;
    public GameObject buildingPrefab;
    public GameObject animalPrefab;
    public int buildCost;
    public int upgradeCost;
}