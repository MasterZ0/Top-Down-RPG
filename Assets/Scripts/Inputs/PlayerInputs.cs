using System;
using UnityEngine;
using CallbackContext = UnityEngine.InputSystem.InputAction.CallbackContext;

namespace BG.Inputs
{
    public class PlayerInputs : BaseInput
    {
        public event Action<bool> OnInteract { add => interaction.OnInputChangeValue += value; remove => interaction.OnInputChangeValue -= value; }
        public event Action<bool> OnSprint { add => sprint.OnInputChangeValue += value; remove => sprint.OnInputChangeValue -= value; }
        public event Action<bool> OnInventory { add => inventory.OnInputChangeValue += value; remove => inventory.OnInputChangeValue -= value; }

        public Vector2 Move => controls.Player.Move.ReadValue<Vector2>();

        private readonly InputButtonRegister inventory;
        private readonly InputButtonRegister interaction;
        private readonly InputButtonRegister sprint;
        private readonly InputButtonRegister primarySkill;
        private readonly InputButtonRegister secondarySkill;

        public PlayerInputs(bool enable = true) : base(enable)
        {
            interaction = new InputButtonRegister(controls.Player.Interact);
            sprint = new InputButtonRegister(controls.Player.Sprint);
            inventory = new InputButtonRegister(controls.UI.Inventory);
        }
    }
}