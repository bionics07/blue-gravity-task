using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _hudContainer;
    [SerializeField]
    private ShopScreen _shopContainer;

    public ShopScreen ShopScreen => _shopContainer;

    public void OpenShopScreen()
    {
        _hudContainer.gameObject.SetActive(false);
        _shopContainer.gameObject.SetActive(true);
    }

    public void CloseShopScreen()
    {
        _hudContainer.gameObject.SetActive(true);
        _shopContainer.gameObject.SetActive(false);
    }
}
