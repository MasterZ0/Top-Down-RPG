using BG.Inputs;
using BG.UI;
using UnityEngine;
using CharacterController = BG.Character.CharacterController;

namespace BG.Player
{
    public class PlayerController : CharacterController
    {
        //[SerializeField] private HUD hud;
        [SerializeField] private EquipmentWindow equipmentScreen;

        public override Vector2 Move => playerInputs.Move;
        private PlayerInputs playerInputs;

        public static PlayerController Instance { get; }

        protected override void Awake()
        {
            base.Awake();
        }

        private void Start()
        {
            playerInputs = new PlayerInputs();
            playerInputs.OnSprint += (value) => IsSprintPressed = value;
            playerInputs.OnInteract += (value) => IsInteractionPressed = value;
            playerInputs.OnInventory += OnInventory;

            equipmentScreen.Init(pawn);
        }

        public override void OnSetActive(bool active) => playerInputs.SetActive(active);

        private void OnInventory(bool value)
        {
            if (value)
            {
                equipmentScreen.OpenWindow();
                playerInputs.SetActive(false);
            }

        }

        public void OnClose() => playerInputs.SetActive(true);

        private void OnDestroy()
        {
            playerInputs.Dispose();
        }
    }
}
