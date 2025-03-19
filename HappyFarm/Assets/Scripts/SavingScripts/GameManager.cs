using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private string saveFilePath;
    private float autoSaveInterval = 5f;

    private void Awake()
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

        saveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");


        StartCoroutine(AutoSaveRoutine());
    }

    private void Start()
    {
        LoadGame(); 
    }

    private IEnumerator AutoSaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveInterval);
            SaveGame();
        }
    }

    public void SaveGame()
    {
        List<SerializableInventoryItem> serializableInventoryItems = new List<SerializableInventoryItem>();

        foreach(var inventoryItem in Warehouse.Instance.GetInventoryData())
        {
            serializableInventoryItems.Add(new SerializableInventoryItem(inventoryItem.Key, inventoryItem.Value));
        }

        SaveData saveData = new SaveData
        {
            playerMoney = FinanceManager.playerMoney,
            buildableLocations = BuildingManager.Instance.GetBuildableLocationsData(),
            inventoryItems = serializableInventoryItems
        };

        string json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Game Saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            FinanceManager.Instance.SetMoneyAmount(saveData.playerMoney);
            BuildingManager.Instance.LoadBuildings(saveData.buildableLocations);
            Dictionary<ProductType, int> inventoryItems = new Dictionary<ProductType, int>();
            foreach (var item in saveData.inventoryItems)
            {
                inventoryItems.Add(item.productType, item.quantity);
            }
            Warehouse.Instance.SetInventoryData(inventoryItems);
            Debug.Log("Game Loaded!");
        }
    }
}

[Serializable]
public class SaveData
{
    public int playerMoney;
    public List<SerializableBuilding> buildableLocations;
    public List<SerializableInventoryItem> inventoryItems;
}
