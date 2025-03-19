using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SellProductUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public Button yesButton;
    public Button noButton;

    private int sellQuantity;
    private InventoryCell selectedCell;

    public void Setup(InventoryCell cell)
    {
        selectedCell = cell;

        sellQuantity = selectedCell.GetProductQuantity();
        int price = selectedCell.GetProductPrice();
        string productName = selectedCell.GetProductName();

        messageText.text = $"Продать {sellQuantity} {productName} за {sellQuantity * price} монет?";
        gameObject.SetActive(true);
    }

    public void OnYesButton()
    {
        if (selectedCell != null)
        {
            selectedCell.SellProduct(sellQuantity);            
        }
        gameObject.SetActive(false);
    }

    public void OnNoButton()
    {
        gameObject.SetActive(false);
    }
}
