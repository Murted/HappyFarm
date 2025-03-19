using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildingInfoUI : MonoBehaviour
{
    public TextMeshProUGUI buildingNameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI upgradeCostText;
    public Button upgradeButton;
    private Animator animator;

    private Building currentBuilding;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowBuildingInfo(Building building)
    {
        currentBuilding = building;

        if (!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            animator.Play("BuildingInfoShow");
        }

        buildingNameText.text = building.GetBuildingName();
        levelText.text = "Уровень: " + building.GetBuildingLevel();
        upgradeCostText.text = "Улучшение: " + building.GetUpgradeCost() + " монет";

        if (FinanceManager.playerMoney >= building.GetUpgradeCost())
        {
            upgradeButton.interactable = true;
        }
        else
        {
            upgradeButton.interactable = false;
        }

        gameObject.SetActive(true);
    }

    public void HidePanel()
    {
        animator.Play("BuildingInfoHide");
        Invoke(nameof(DisablePanel), 0.5f);
    }

    private void DisablePanel()
    {
        gameObject.SetActive(false);
    }

    public void OnUpgradeButtonClicked()
    {
        FinanceManager.Instance.UpgradeBuilding(currentBuilding);
        HidePanel();
    }
}
