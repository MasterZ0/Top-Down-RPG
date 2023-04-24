using System;
using UnityEngine.InputSystem;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace TD.Inputs
{
    public class InputButtonRegister
    {
        public event Action<bool> OnInputChangeValue;

        public InputButtonRegister(InputAction action)
        {
            action.started += SendInputDown;
            action.canceled += SendInputUp;
        }

        private void SendInputDown(CallbackContext _) => OnInputChangeValue?.Invoke(true);
        private void SendInputUp(CallbackContext _) => OnInputChangeValue?.Invoke(false);
    }
}