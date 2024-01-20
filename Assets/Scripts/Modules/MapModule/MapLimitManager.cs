public class MapLimitManager
{
    private MapLimitConfig _limitConfig;
    private CharacterView _characterView;

    public MapLimitManager(MapLimitConfig mapLimitConfig, CharacterView characterView)
    {
        _limitConfig = mapLimitConfig;
        _characterView = characterView;
    }

    public bool CanMoveToRight()
    {
        return _characterView.transform.position.x < _limitConfig.HorizontalRightLimit;
    }

    public bool CanMoveToLeft()
    {
        return _characterView.transform.position.x > _limitConfig.HorizontalLeftLimit;
    }

    public bool CanMoveToUp()
    {
        return _characterView.transform.position.y < _limitConfig.VerticalUpLimit;
    }

    public bool CanMoveToDown()
    {
        return _characterView.transform.position.y > _limitConfig.VerticalDownLimit;
    }
}
