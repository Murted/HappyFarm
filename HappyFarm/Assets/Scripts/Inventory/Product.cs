using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ProductConfig", menuName = "Config/ProductConfig")]
public class ProductData : ScriptableObject
{
    public List<ProductInfo> products = new List<ProductInfo>();

    public int GetProductPrice(ProductType type)
    {
        foreach (var product in products)
        {
            if (product.type == type)
            {
                return product.sellPrice;
            }
        }
        return 0;
    }
}

[System.Serializable]
public class ProductInfo
{
    public ProductType type;
    public string ProductName;
    public int sellPrice;
}
