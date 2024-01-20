[System.Serializable]
public struct CharacterAnimationParams
{
    public string AnimationKey;
    public int BodySkinIndex;
    public int ClothesSkinIndex;
    public int HairSkinIndex;
    public int HatSkinIndex;

    public CharacterAnimationParams(string animationKey, int bodyIndex, int clothesIndex, int hairIndex, int hatIndex)
    {
        AnimationKey = animationKey;
        BodySkinIndex = bodyIndex;
        ClothesSkinIndex = clothesIndex;
        HairSkinIndex = hairIndex;
        HatSkinIndex = hatIndex;
    }
}
