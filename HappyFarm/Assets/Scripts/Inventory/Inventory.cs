using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public List<InventoryCell> inventoryCells;
    public ProductData productData;

    public void UpdateInventoryUI(Dictionary<ProductType, int> products)
    {
        int index = 0;

        foreach (var product in products)
        {
            if (index >= inventoryCells.Count) break;

            int price = productData.GetProductPrice(product.Key);
            inventoryCells[index].SetProduct(product.Key, product.Value, price);
            index++;
        }
    }
}
