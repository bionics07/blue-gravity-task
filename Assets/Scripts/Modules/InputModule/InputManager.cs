using System;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private List<InputAction> _getKeyDownCallbacks = new List<InputAction>();
    private List<InputAction> _getKeyCallbacks = new List<InputAction>();
    private List<InputAction> _getKeyUpCallbacks = new List<InputAction>();

    private void Update()
    {
        foreach (InputAction inputAction in _getKeyDownCallbacks)
        {
            if (Input.GetKeyDown(inputAction.KeyCode))
            {
                inputAction.Callback?.Invoke(inputAction.KeyCode);
            }
        }

        foreach (InputAction inputAction in _getKeyCallbacks)
        {
            if (Input.GetKey(inputAction.KeyCode))
            {
                inputAction.Callback?.Invoke(inputAction.KeyCode);
            }
        }

        foreach (InputAction inputAction in _getKeyUpCallbacks)
        {
            if (Input.GetKeyUp(inputAction.KeyCode))
            {
                inputAction.Callback?.Invoke(inputAction.KeyCode);
            }
        }
    }

    public void AddGetKeyDownInputCallback(KeyCode keyCode, Action<KeyCode> callback)
    {
        foreach (InputAction inputAction in _getKeyDownCallbacks)
        {
            if(inputAction.KeyCode == keyCode)
            {
                inputAction.Callback += callback;
                return;
            }
        }

        _getKeyDownCallbacks.Add(new InputAction(keyCode, callback));
    }

    public void AddGetKeyInputCallback(KeyCode keyCode, Action<KeyCode> callback)
    {
        foreach (InputAction inputAction in _getKeyCallbacks)
        {
            if (inputAction.KeyCode == keyCode)
            {
                inputAction.Callback += callback;
                return;
            }
        }

        _getKeyCallbacks.Add(new InputAction(keyCode, callback));
    }

    public void AddGetKeyUpInputCallback(KeyCode keyCode, Action<KeyCode> callback)
    {
        foreach (InputAction inputAction in _getKeyUpCallbacks)
        {
            if (inputAction.KeyCode == keyCode)
            {
                inputAction.Callback += callback;
                return;
            }
        }

        _getKeyUpCallbacks.Add(new InputAction(keyCode, callback));
    }

    public class InputAction
    {
        public KeyCode KeyCode;
        public Action<KeyCode> Callback;

        public InputAction(KeyCode keyCode, Action<KeyCode> callback)
        {
            KeyCode = keyCode;
            Callback = callback;
        }
    }
}
