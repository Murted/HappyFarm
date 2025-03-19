using UnityEngine;

public class ShowCraft : MonoBehaviour
{
    public ShowInventory inventoryPanel;
    public CraftingSystem craftingSystem;

    private Animator animator;

    public void Awake()
    {
        animator = craftingSystem.GetComponent<Animator>();
    }

    public void OnCraftingButtonClicked()
    {
        if (inventoryPanel.inventory.gameObject.activeSelf)
        {
            inventoryPanel.HidePanel();
        }
        craftingSystem.gameObject.SetActive(true);
        animator.Play("CraftingPanelShow");
    }

    public void HidePanel()
    {
        animator.Play("CraftingPanelHide");
        Invoke(nameof(DisablePanel), 0.5f);
    }

    private void DisablePanel()
    {
        craftingSystem.gameObject.SetActive(false);
    }
}
