public class CharacterInteractionService
{
    public void OnInteractWithRockArea()
    {
        ServiceLocator.Instance.InventoryManager.AddItem(ItemKeys.ROCK, 1);
    }

    public void OnInteractWithSellArea()
    {
        if (ServiceLocator.Instance.InventoryManager.GetItemQuantity(ItemKeys.ROCK) >= 5)
        {
            ServiceLocator.Instance.InventoryManager.RemoveItem(ItemKeys.ROCK, 5);
            ServiceLocator.Instance.InventoryManager.AddItem(ItemKeys.COIN, 1);
        }
    }  

    public void OnInteractWithShopArea()
    {
        ServiceLocator.Instance.UIManager.OpenShopScreen();
    }
}
