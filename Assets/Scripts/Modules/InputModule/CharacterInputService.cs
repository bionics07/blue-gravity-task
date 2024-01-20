using UnityEngine;

public class CharacterInputService : MonoBehaviour
{
    private CharacterView _characterView;

    private KeyCode _lastKeyCodePressed = KeyCode.None;

    public CharacterInputService(CharacterView characterView)
    {

        _characterView = characterView;
        ServiceLocator.Instance.InputManager.AddGetKeyInputCallback(KeyCode.W, OnMoveUp);
        ServiceLocator.Instance.InputManager.AddGetKeyInputCallback(KeyCode.S, OnMoveDown);
        ServiceLocator.Instance.InputManager.AddGetKeyInputCallback(KeyCode.D, OnMoveRight);
        ServiceLocator.Instance.InputManager.AddGetKeyInputCallback(KeyCode.A, OnMoveLeft);

        ServiceLocator.Instance.InputManager.AddGetKeyDownInputCallback(KeyCode.W, SetLastKeyCode);
        ServiceLocator.Instance.InputManager.AddGetKeyDownInputCallback(KeyCode.S, SetLastKeyCode);
        ServiceLocator.Instance.InputManager.AddGetKeyDownInputCallback(KeyCode.D, SetLastKeyCode);
        ServiceLocator.Instance.InputManager.AddGetKeyDownInputCallback(KeyCode.A, SetLastKeyCode);

        ServiceLocator.Instance.InputManager.AddGetKeyUpInputCallback(KeyCode.W, OnKeyCodeUp);
        ServiceLocator.Instance.InputManager.AddGetKeyUpInputCallback(KeyCode.S, OnKeyCodeUp);
        ServiceLocator.Instance.InputManager.AddGetKeyUpInputCallback(KeyCode.D, OnKeyCodeUp);
        ServiceLocator.Instance.InputManager.AddGetKeyUpInputCallback(KeyCode.A, OnKeyCodeUp);

        ServiceLocator.Instance.InputManager.AddGetKeyDownInputCallback(KeyCode.J, OnInteract);
    }

    private void OnMoveUp(KeyCode keyCode)
    {
        if (_lastKeyCodePressed == keyCode)
        {
            ServiceLocator.Instance.CharacterMovementManager.OnMoveUp();
            ServiceLocator.Instance.CharacterAnimationManager.SetAnimation("MoveUp");
        }
    }

    private void OnMoveDown(KeyCode keyCode)
    {
        if (_lastKeyCodePressed == keyCode)
        {
            ServiceLocator.Instance.CharacterMovementManager.OnMoveDown();
            ServiceLocator.Instance.CharacterAnimationManager.SetAnimation("MoveDown");
        }
    }

    private void OnMoveRight(KeyCode keyCode)
    {
        if (_lastKeyCodePressed == keyCode)
        {
            ServiceLocator.Instance.CharacterMovementManager.OnMoveRight();
            ServiceLocator.Instance.CharacterAnimationManager.SetAnimation("MoveRight");
        }
    }

    private void OnMoveLeft(KeyCode keyCode)
    {
        if(_lastKeyCodePressed == keyCode)
        {
            ServiceLocator.Instance.CharacterMovementManager.OnMoveLeft();
            ServiceLocator.Instance.CharacterAnimationManager.SetAnimation("MoveLeft");
        }
    }

    private void SetLastKeyCode(KeyCode keyCode)
    {
        _lastKeyCodePressed = keyCode;
    }

    private void OnKeyCodeUp(KeyCode keyCode)
    {
        if(keyCode == _lastKeyCodePressed)
        {
            ServiceLocator.Instance.CharacterAnimationManager.SetAnimation("Idle");
        }
    }

    public void OnInteract(KeyCode keyCode)
    {
        if (ServiceLocator.Instance.CharacterCollisionManager.IsOnRockArea)
        {
            ServiceLocator.Instance.CharacterInteractionService.OnInteractWithRockArea();
        }
        else if (ServiceLocator.Instance.CharacterCollisionManager.IsOnSellArea)
        {
            ServiceLocator.Instance.CharacterInteractionService.OnInteractWithSellArea();
        }
        else if (ServiceLocator.Instance.CharacterCollisionManager.IsOnShopArea)
        {
            ServiceLocator.Instance.CharacterInteractionService.OnInteractWithShopArea();
        }
    }
}
