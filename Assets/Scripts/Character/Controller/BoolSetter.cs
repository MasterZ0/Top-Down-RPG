using System;
namespace TD.Character
{
    public class BoolSetter
    {
        public event Action OnValueTrue;
        public event Action OnValueFalse;

        public bool Value { get; private set; }

        public void Set(bool value)
        {
            Value = value;

            if (value)
            {
                OnValueTrue?.Invoke();
            }
            else
            {
                OnValueFalse?.Invoke();
            }
        }
    }
}