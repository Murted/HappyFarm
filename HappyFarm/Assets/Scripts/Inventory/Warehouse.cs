using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour
{
    public static Warehouse Instance;

    private Dictionary<ProductType, int> products = new Dictionary<ProductType, int>();

    public Inventory inventory;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Dictionary<ProductType, int> GetInventoryData()
    {
        return products;
    }

    public void SetInventoryData(Dictionary<ProductType, int> savedProducts)
    {
        products = savedProducts;
    }

    public void AddProduct(ProductType productType, int amount = 1)
    {
        if (!products.ContainsKey(productType))
        {
            if (products.Count >= 5)
            {
                return;
            }

            products[productType] = 0;
        }

        products[productType] += amount;
        inventory.UpdateInventoryUI(products);
    }

    public void RemoveProduct(ProductType productType, int amount)
    {
        if (!products.ContainsKey(productType)) return;

        products[productType] -= amount;
        if (products[productType] <= 0)
        {
            products.Remove(productType);
        }

        inventory.UpdateInventoryUI(products);
    }

    public int GetProductCount(ProductType productType)
    {
        return products.ContainsKey(productType) ? products[productType] : 0;
    }
}
