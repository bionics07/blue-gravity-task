using UnityEngine;

public class CharacterMovementManager
{

    private CharacterView _character;
    private CharacterMovementConfig _movementConfig;

    public CharacterMovementManager(CharacterView characterView, CharacterMovementConfig characterMovementConfig)
    {
        _character = characterView;
        _movementConfig = characterMovementConfig;
    }

    public void OnMoveUp()
    {
        if (ServiceLocator.Instance.MapLimitManager.CanMoveToUp())
        {
            float currentYPosition = _character.transform.position.y;
            currentYPosition += _movementConfig.CharacterVerticalSpeed;

            _character.transform.position = new Vector2(_character.transform.position.x, currentYPosition);
        }
    }

    public void OnMoveDown()
    {
        if (ServiceLocator.Instance.MapLimitManager.CanMoveToDown())
        {
            float currentYPosition = _character.transform.position.y;
            currentYPosition -= _movementConfig.CharacterVerticalSpeed;

            _character.transform.position = new Vector2(_character.transform.position.x, currentYPosition);
        }
    }

    public void OnMoveRight()
    {
        if (ServiceLocator.Instance.MapLimitManager.CanMoveToRight())
        {
            float currentXPosition = _character.transform.position.x;
            currentXPosition += _movementConfig.CharacterHorizontalSpeed;

            _character.transform.position = new Vector2(currentXPosition, _character.transform.position.y);
        }
    }

    public void OnMoveLeft()
    {
        if (ServiceLocator.Instance.MapLimitManager.CanMoveToLeft())
        {
            float currentXPosition = _character.transform.position.x;
            currentXPosition -= _movementConfig.CharacterHorizontalSpeed;

            _character.transform.position = new Vector2(currentXPosition, _character.transform.position.y);
        }
    }
}
