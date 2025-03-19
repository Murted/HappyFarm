[System.Serializable]
public class SerializableInventoryItem
{
    public ProductType productType;
    public int quantity;

    public SerializableInventoryItem(ProductType productType, int quantity)
    {
        this.productType = productType;
        this.quantity = quantity;
    }
}