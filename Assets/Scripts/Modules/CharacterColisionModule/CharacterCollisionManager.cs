using UnityEngine;

public class CharacterCollisionManager
{
    public bool IsOnSellArea { get; private set; }
    public bool IsOnRockArea { get; private set; }
    public bool IsOnShopArea { get; private set; }

    private const string SHOP_AREA_OBJECT_NAME = "ShopArea";
    private const string ROCK_AREA_OBJECT_NAME = "StoneArea";
    private const string SELL_AREA_OBJECT_NAME = "SellArea";

    public void OnTriggerEnter(Collider2D collision)
    {
        if(collision.gameObject.name == SHOP_AREA_OBJECT_NAME)
        {
            IsOnShopArea = true;
        }
        else if (collision.gameObject.name == ROCK_AREA_OBJECT_NAME)
        {
            IsOnRockArea = true;
        }
        else if (collision.gameObject.name == SELL_AREA_OBJECT_NAME)
        {
            IsOnSellArea = true;
        }
    }

    public void OnTriggerExit(Collider2D collision)
    {
        if (collision.gameObject.name == SHOP_AREA_OBJECT_NAME)
        {
            IsOnShopArea = false;
        }
        else if (collision.gameObject.name == ROCK_AREA_OBJECT_NAME)
        {
            IsOnRockArea = false;
        }
        else if (collision.gameObject.name == SELL_AREA_OBJECT_NAME)
        {
            IsOnSellArea = false;
        }
    }
}
