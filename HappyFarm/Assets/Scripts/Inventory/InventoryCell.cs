using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCell : MonoBehaviour
{
    public TextMeshProUGUI productQuantityText;
    public Image productIcon;
    public SellProductUI sellProductUI;

    private ProductType productType;
    private int quantity;
    private int sellPrice;

    public bool IsEmpty = true;

    public void SetProduct(ProductType type, int quantity, int price)
    {
        productType = type;
        this.quantity = quantity;
        sellPrice = price;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (quantity > 0)
        {
            productQuantityText.text = quantity.ToString();
            productIcon.sprite = GetProductIcon(productType);
            IsEmpty = false;
            productIcon.gameObject.SetActive(true);
        }
        else
        {
            productQuantityText.text = "";
            productIcon.sprite = null;
            IsEmpty = true;
        }
    }

    private Sprite GetProductIcon(ProductType type)
    {
        productQuantityText.gameObject.SetActive(true);
        return Resources.Load<Sprite>($"Icons/{type}");
    }

    public void OnClick()
    {
        if (quantity > 0 && sellProductUI != null)
        {
            sellProductUI.Setup(this);
        }
    }

    public void SellProduct(int sellQuantity)
    {
        if (quantity <= 0) return;

        quantity -= sellQuantity;
        if (quantity <= 0)
        {
            IsEmpty = true;
        }

        FinanceManager.Instance.SellProduct(sellQuantity, sellPrice);
        Warehouse.Instance.RemoveProduct(productType, sellQuantity);

        UpdateUI();
    }

    public int GetProductQuantity()
    {
        return quantity;
    }

    public string GetProductName()
    {
        return productType.ToString();
    }

    public int GetProductPrice()
    {
        return sellPrice;
    }
}
