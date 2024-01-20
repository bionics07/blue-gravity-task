using UnityEngine;

[CreateAssetMenu(fileName = "CharacterMovementConfig", menuName = "ScriptableObjects/CharacterMovementConfig")]
public class CharacterMovementConfig : ScriptableObject
{
    [SerializeField] private float _characterHorizontalSpeed;
    [SerializeField] private float _characterVerticalSpeed;

    public float CharacterHorizontalSpeed => _characterHorizontalSpeed;
    public float CharacterVerticalSpeed => _characterVerticalSpeed;
}
