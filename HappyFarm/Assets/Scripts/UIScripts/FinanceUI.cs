using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinanceUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI balanceText;

    private void Awake()
    {
        balanceText.text = $"������: {FinanceManager.playerMoney}";
        FinanceManager.OnMoneyUpdated += OnBalanceChanged;
    }

    public void OnBalanceChanged()
    {
        balanceText.text = $"������: {FinanceManager.playerMoney}";
    }

    private void OnDestroy()
    {
        FinanceManager.OnMoneyUpdated -= OnBalanceChanged;
    }
}