using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScreen : MonoBehaviour
{
    [SerializeField]
    private List<SkinInfo> _skinInfos;
    [SerializeField]
    private Button _closeScreenButton;

    private void Start()
    {
        _closeScreenButton.onClick.AddListener(CloseScreen);
    }

    private void CloseScreen()
    {
        ServiceLocator.Instance.UIManager.CloseShopScreen();
        ServiceLocator.Instance.CharacterAnimationManager.SetAnimation("Idle");
    }

    public SkinInfo GetSkinInfo(SkinType skinType, int index)
    {
        foreach (SkinInfo skinInfo in _skinInfos)
        {
            if(skinInfo.SkinType == skinType && skinInfo.SkinIndex == index)
            {
                return skinInfo;
            }
        }

        return null;
    }

    public void UnequipAllSkins(SkinType skinType)
    {
        foreach (SkinInfo skinInfo in _skinInfos)
        {
            if (skinInfo.SkinType == skinType)
            {
                skinInfo.IsEquiped = false;
            }
        }
    }

    public void BuySkin(SkinInfo skinInfo)
    {
        skinInfo.IsAvailable = true;
        ServiceLocator.Instance.InventoryManager.RemoveItem(ItemKeys.COIN, skinInfo.SkinPrice);
    }

    public int GetMaxIndex(SkinType skinType)
    {
        int maxIndex = 0;

        foreach (SkinInfo skinInfo in _skinInfos)
        {
            if (skinInfo.SkinType == skinType && skinInfo.SkinIndex > maxIndex)
            {
                maxIndex = skinInfo.SkinIndex;
            }
        }

        return maxIndex;
    }
}
