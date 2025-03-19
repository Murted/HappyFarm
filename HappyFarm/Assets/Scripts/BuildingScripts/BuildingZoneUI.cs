using TMPro;
using UnityEngine;

public class BuildingZoneUI : MonoBehaviour
{
    public TextMeshProUGUI ChickenCoopText;
    public TextMeshProUGUI SheepPenText;
    public TextMeshProUGUI CowBarnText;

    private int chosenZoneIndex;
    private Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowZoneUI(int zoneIndex)
    {
        chosenZoneIndex = zoneIndex;
        ChickenCoopText.text = $"{BuildingDataProvider.Instance.GetBuildingData(BuildingType.ChickenCoop).BuildingName}: {BuildingDataProvider.Instance.GetBuildingData(BuildingType.ChickenCoop).buildCost} монет";
        SheepPenText.text = $"{BuildingDataProvider.Instance.GetBuildingData(BuildingType.SheepPen).BuildingName}: {BuildingDataProvider.Instance.GetBuildingData(BuildingType.SheepPen).buildCost} монет";
        CowBarnText.text = $"{BuildingDataProvider.Instance.GetBuildingData(BuildingType.CowBarn).BuildingName}: {BuildingDataProvider.Instance.GetBuildingData(BuildingType.CowBarn).buildCost} монет";
        gameObject.SetActive(true);
        animator.Play("BuyBuildingInfoShow");
    }

    public void OnChickenCoopButtonClicked()
    {
        FinanceManager.Instance.PurchaseBuilding(BuildingType.ChickenCoop, chosenZoneIndex);
        HideZoneUI();
    } 
    
    public void OnSheepPenButtonClicked()
    {
        FinanceManager.Instance.PurchaseBuilding(BuildingType.SheepPen, chosenZoneIndex);
        HideZoneUI();
    }

    public void OnCowBarnButtonClicked()
    {
        FinanceManager.Instance.PurchaseBuilding(BuildingType.CowBarn, chosenZoneIndex);
        HideZoneUI();
    }

    public void HideZoneUI()
    {
        animator.Play("BuyBuildingInfoHide");
        Invoke(nameof(DisablePanel), 0.5f);
    }

    private void DisablePanel()
    {
        gameObject.SetActive(false);
    }
}
