using TMPro;
using UnityEngine;

public class ItemHUD : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _quantityText;
    [SerializeField]
    private ItemKeys _itemKey;

    private void Start()
    {
        ServiceLocator.Instance.ObserverService.SubscribeOnStorageUpdateListener(UpdateItemQuantity);
    }

    public void UpdateItemQuantity(ItemKeys itemKey, int currentQuantity)
    {
        if(itemKey == _itemKey)
        {
            _quantityText.text = $"x{currentQuantity}";
        }
    }
}
