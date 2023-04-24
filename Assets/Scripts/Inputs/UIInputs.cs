using System;

namespace TD.Inputs
{
    public class UIInputs : BaseInput
    {
        public event Action<bool> OnSubmit { add => submit.OnInputChangeValue += value; remove => submit.OnInputChangeValue -= value; }
        public event Action<bool> OnCancel { add => cancel.OnInputChangeValue += value; remove => cancel.OnInputChangeValue -= value; }
        public event Action<bool> OnInventory { add => inventory.OnInputChangeValue += value; remove => inventory.OnInputChangeValue -= value; }


        private readonly InputButtonRegister submit;
        private readonly InputButtonRegister cancel;
        private readonly InputButtonRegister inventory;

        public UIInputs(bool enable) : base(enable)
        {
            submit = new InputButtonRegister(controls.UI.Submit);
            cancel = new InputButtonRegister(controls.UI.Cancel);
            inventory = new InputButtonRegister(controls.UI.Inventory);
        }
    }
}