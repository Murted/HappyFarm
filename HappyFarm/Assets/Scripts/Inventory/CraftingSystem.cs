using UnityEngine;
using UnityEngine.UI;

public class CraftingSystem : MonoBehaviour
{
    public void CraftCheese()
    {
        if (Warehouse.Instance.GetProductCount(ProductType.Milk) >= 2)
        {
            Warehouse.Instance.RemoveProduct(ProductType.Milk, 2);
            Warehouse.Instance.AddProduct(ProductType.Cheese, 1);
        }
    }

    public void CraftCurd()
    {
        if (Warehouse.Instance.GetProductCount(ProductType.Milk) >= 3)
        {
            Warehouse.Instance.RemoveProduct(ProductType.Milk, 3);
            Warehouse.Instance.AddProduct(ProductType.Curd, 1);
        }
    }
}
