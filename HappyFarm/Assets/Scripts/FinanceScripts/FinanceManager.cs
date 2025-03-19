using System;
using System.Collections.Generic;
using UnityEngine;

public class FinanceManager : MonoBehaviour
{
    public static FinanceManager Instance;

    public static int playerMoney = 1000;
    public delegate void PurchaseBuildingDelegate(PurchaseData purchaseData);
    public static event PurchaseBuildingDelegate OnPurchaseCompleted;

    public delegate void UpgradeBuildingDelegate(Building building);
    public static event UpgradeBuildingDelegate OnUpgradeCompleted;

    public static Action OnMoneyUpdated;


    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool PurchaseBuilding(BuildingType buildingType, int locationIndex)
    {
        int buildingCost = 0;

        foreach (var buildingData in BuildingDataProvider.Instance.buildingDataList)
        {
            if(buildingType == buildingData.type)
            {
                buildingCost = buildingData.buildCost;
                break;
            }
        }

        if (playerMoney >= buildingCost)
        {
            playerMoney -= buildingCost;

            PurchaseData purchaseData = new PurchaseData(buildingType, locationIndex);

            OnPurchaseCompleted?.Invoke(purchaseData);
            OnMoneyUpdated?.Invoke();

            return true;
        }
        else
        {
            return false;
        }
    }

    public bool UpgradeBuilding(Building building)
    {
        if (playerMoney >= building.GetUpgradeCost())
        {
            playerMoney -= building.GetUpgradeCost();

            OnUpgradeCompleted?.Invoke(building);
            OnMoneyUpdated?.Invoke();

            return true;
        }
        else
        {
            return false;
        }
    }

    public void SellProduct(int amount, int price)
    {
        int totalMoney = amount * price;
        playerMoney += totalMoney;

        OnMoneyUpdated?.Invoke();
    }

    public void SetMoneyAmount(int moneyAmount)
    {
        playerMoney = moneyAmount;
        OnMoneyUpdated?.Invoke();
    }
}
