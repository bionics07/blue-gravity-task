using UnityEngine;

[CreateAssetMenu(fileName = "MapLimitConfig", menuName = "ScriptableObjects/MapLimitConfig")]
public class MapLimitConfig : ScriptableObject
{
    [SerializeField] private float _verticalUpLimit;
    [SerializeField] private float _verticalDownLimit;
    [SerializeField] private float _horizontalRightLimit;
    [SerializeField] private float _horizontalLeftLimit;

    public float VerticalUpLimit => _verticalUpLimit;
    public float VerticalDownLimit => _verticalDownLimit;
    public float HorizontalRightLimit => _horizontalRightLimit;
    public float HorizontalLeftLimit => _horizontalLeftLimit;
}
