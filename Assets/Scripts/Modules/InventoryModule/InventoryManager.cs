using System.Collections.Generic;

public class InventoryManager
{
    public Dictionary<ItemKeys, int> ItemsQuantity = new Dictionary<ItemKeys, int>();

    public void AddItem(ItemKeys itemKey, int quantity)
    {
        if (!ItemsQuantity.ContainsKey(itemKey))
        {
            ItemsQuantity.Add(itemKey, 0);
        }

        ItemsQuantity[itemKey] += quantity;
        ServiceLocator.Instance.ObserverService.FireOnStorageUpdate(itemKey, ItemsQuantity[itemKey]);
    }

    public void RemoveItem(ItemKeys itemKey, int quantity)
    {
        if (!ItemsQuantity.ContainsKey(itemKey))
        {
            ItemsQuantity.Add(itemKey, 0);
        }

        ItemsQuantity[itemKey] -= quantity;
        ServiceLocator.Instance.ObserverService.FireOnStorageUpdate(itemKey, ItemsQuantity[itemKey]);
    }

    public int GetItemQuantity(ItemKeys itemKey)
    {
        if (ItemsQuantity.ContainsKey(itemKey))
        {
            return ItemsQuantity[itemKey];
        }
        else
        {
            return 0;
        }
    }
}
