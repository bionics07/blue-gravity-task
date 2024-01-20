using UnityEngine;

[CreateAssetMenu(fileName = "CharacterAnimationConfig", menuName = "ScriptableObjects/CharacterAnimationConfig")]
public class CharacterAnimationConfig : ScriptableObject
{
    [SerializeField] private CharacterAnimations[] _characterAnimations;

    public CharacterAnimations[] CharacterAnimations => _characterAnimations;
}
