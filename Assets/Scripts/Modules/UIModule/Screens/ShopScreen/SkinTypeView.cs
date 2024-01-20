using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinTypeView : MonoBehaviour
{
    [SerializeField]
    private SkinType _skinType;
    [SerializeField]
    private Button _nextItemButton;
    [SerializeField]
    private Button _previousItemButton;
    [SerializeField]
    private Image _skinImage;

    [Header("EquipSkinContainer")]
    [SerializeField]
    private GameObject _equipSkinContainer;
    [SerializeField]
    private Button _equipSkinButton;
    [SerializeField]
    private TextMeshProUGUI _equipSkinButtonText;

    [Header("BuySkinContainer")]
    [SerializeField]
    private GameObject _costTextContainer;
    [SerializeField]
    private Button _buySkinButton;
    [SerializeField]
    private TextMeshProUGUI _costText;

    private int _currentSkinIndex = 0;

    private void Start()
    {
        SkinInfo skinInfo = ServiceLocator.Instance.UIManager.ShopScreen.GetSkinInfo(_skinType, _currentSkinIndex);
        SetView(skinInfo);
        _buySkinButton.onClick.AddListener(BuySkinButton);
        _equipSkinButton.onClick.AddListener(EquipSkinButton);
        _nextItemButton.onClick.AddListener(NextSkinButton);
        _previousItemButton.onClick.AddListener(PreviousSkinButton);
        
    }

    private void EquipSkinButton()
    {
        SkinInfo skinInfo = ServiceLocator.Instance.UIManager.ShopScreen.GetSkinInfo(_skinType, _currentSkinIndex);
        ServiceLocator.Instance.UIManager.ShopScreen.UnequipAllSkins(_skinType);
        EquipSkin(skinInfo);
        SetView(skinInfo);
    }

    private void BuySkinButton()
    {
        SkinInfo skinInfo = ServiceLocator.Instance.UIManager.ShopScreen.GetSkinInfo(_skinType, _currentSkinIndex);
        int currentCoins = ServiceLocator.Instance.InventoryManager.ItemsQuantity[ItemKeys.COIN];

        if (currentCoins >= skinInfo.SkinPrice)
        {
            ServiceLocator.Instance.UIManager.ShopScreen.BuySkin(skinInfo);
            EquipSkinButton();
        }
    }

    private void NextSkinButton()
    {
        _currentSkinIndex++;
        SkinInfo skinInfo = ServiceLocator.Instance.UIManager.ShopScreen.GetSkinInfo(_skinType, _currentSkinIndex);

        if(skinInfo == null)
        {
            _currentSkinIndex = 0;
            skinInfo = ServiceLocator.Instance.UIManager.ShopScreen.GetSkinInfo(_skinType, _currentSkinIndex);
        }

        SetView(skinInfo);
    }

    private void PreviousSkinButton()
    {
        _currentSkinIndex--;
        SkinInfo skinInfo = ServiceLocator.Instance.UIManager.ShopScreen.GetSkinInfo(_skinType, _currentSkinIndex);

        if (skinInfo == null)
        {
            _currentSkinIndex = ServiceLocator.Instance.UIManager.ShopScreen.GetMaxIndex(_skinType);
            skinInfo = ServiceLocator.Instance.UIManager.ShopScreen.GetSkinInfo(_skinType, _currentSkinIndex);
        }

        SetView(skinInfo);
    }

    private void SetView(SkinInfo skinInfo)
    {
        _skinImage.sprite = skinInfo.SkinSprite;

        if (skinInfo.IsAvailable)
        {
            SetSkinAvailableView(skinInfo);
        }
        else
        {
            SetSkinUnavailableView(skinInfo);
        }
    }

    private void SetSkinUnavailableView(SkinInfo skinInfo)
    {
        _equipSkinContainer.gameObject.SetActive(false);
        _costTextContainer.SetActive(true);
        _costText.text = $"x{skinInfo.SkinPrice}";
    }

    private void SetSkinAvailableView(SkinInfo skinInfo)
    {
        _equipSkinContainer.gameObject.SetActive(true);
        _costTextContainer.SetActive(false);
        if (skinInfo.IsEquiped)
        {
            _equipSkinButtonText.text = "Equiped";
            _equipSkinButton.interactable = false;
        }
        else
        {
            _equipSkinButtonText.text = "Set";
            _equipSkinButton.interactable = true;
        }
    }

    private void EquipSkin(SkinInfo skinInfo)
    {
        CharacterAnimationParams currentAnimationParams = ServiceLocator.Instance.CharacterView.CurrentAnimationParams;
        skinInfo.IsEquiped = true;

        switch (_skinType)
        {
            case SkinType.BODY:
                ServiceLocator.Instance.CharacterView.SetCurrentAnimationParams(new CharacterAnimationParams("Idle", _currentSkinIndex,
                    currentAnimationParams.ClothesSkinIndex, currentAnimationParams.HairSkinIndex, currentAnimationParams.HatSkinIndex));
                break;
            case SkinType.CLOTHES:
                ServiceLocator.Instance.CharacterView.SetCurrentAnimationParams(new CharacterAnimationParams("Idle", currentAnimationParams.BodySkinIndex,
                    _currentSkinIndex, currentAnimationParams.HairSkinIndex, currentAnimationParams.HatSkinIndex));
                break;
            case SkinType.HAIR:
                ServiceLocator.Instance.CharacterView.SetCurrentAnimationParams(new CharacterAnimationParams("Idle", currentAnimationParams.BodySkinIndex,
                    currentAnimationParams.ClothesSkinIndex, _currentSkinIndex, currentAnimationParams.HatSkinIndex));
                break;
            case SkinType.HAT:
                ServiceLocator.Instance.CharacterView.SetCurrentAnimationParams(new CharacterAnimationParams("Idle", currentAnimationParams.BodySkinIndex,
                    currentAnimationParams.ClothesSkinIndex, currentAnimationParams.HairSkinIndex, _currentSkinIndex));
                break;
            default:
                break;
        }
    }
}
