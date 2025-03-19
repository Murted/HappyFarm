using UnityEngine;
using UnityEngine.EventSystems;

public class BuildableLocation : MonoBehaviour
{
    public int zoneIndex;
    public Building currentBuilding;

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        BuildingManager.Instance.OnBuildingZoneClicked(this);
    }
}