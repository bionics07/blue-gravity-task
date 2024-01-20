using UnityEngine;

[CreateAssetMenu(fileName = "SkinInfo", menuName = "ScriptableObjects/SkinInfo")]
public class SkinInfo : ScriptableObject
{
    [SerializeField] private SkinType _skinType;
    [SerializeField] private int _skinIndex;
    [SerializeField] private int _skinPrice;
    [SerializeField] private Sprite _skinSprite;

    public bool IsAvailable;
    public bool IsEquiped;

    public SkinType SkinType => _skinType;
    public int SkinIndex => _skinIndex;
    public int SkinPrice => _skinPrice;
    public Sprite SkinSprite => _skinSprite;

}

public enum SkinType
{
    BODY,
    CLOTHES,
    HAIR,
    HAT
}
