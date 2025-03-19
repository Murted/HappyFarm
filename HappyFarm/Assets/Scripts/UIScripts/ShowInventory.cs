using UnityEngine;

public class ShowInventory : MonoBehaviour
{
    public Inventory inventory;
    public ShowCraft craftingPanel;

    private Animator animator;

    public void Awake()
    {
        animator = inventory.GetComponent<Animator>();
    }

    public void OnInventoryButtonClicked()
    {
        if (craftingPanel.craftingSystem.gameObject.activeSelf)
        {
            craftingPanel.HidePanel();
        }
        inventory.gameObject.SetActive(true);
        animator.Play("InventoryPanelShow");
    }

    public void HidePanel()
    {
        animator.Play("InventoryPanelHide");
        Invoke(nameof(DisablePanel), 0.5f);
    }

    private void DisablePanel()
    {
        inventory.gameObject.SetActive(false);
    }
}
