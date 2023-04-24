using UnityEngine;
using TD.Data;
using TD.Items;

namespace TD.Character
{
    public interface IInteractable
    {
        public bool OnInteract(CharacterPawn character);
    }

    public sealed class CharacterPawn : MonoBehaviour
    {
        [Header("Character Controller")]
        [SerializeField] private CharacterData data;
        [SerializeField] private DefaultInventory defaultInventory;
        [SerializeField] private ModelController modelController;
        [Space]
        [SerializeField] private CharacterPhysics characterPhysics;
        [SerializeField] private CharacterAnimator characterAnimator;
        [SerializeField] private CharacterInventoryController characterInventoryController;

        public CharacterInventoryController Inventory => characterInventoryController;
        public CharacterData Data => data;
        public CharacterPhysics Physics => characterPhysics;
        public CharacterAnimator Animator => characterAnimator;
        public ModelController ModelController => modelController;
        public CharacterController Controller { get; private set; }
        public DefaultInventory DefaultInventory => defaultInventory;

        private void Awake()
        {
            characterPhysics.Init(this);
            characterAnimator.Init(this);
            characterInventoryController.Init(this);
        }

        public void SetActiveController(bool active) => Controller.OnSetActive(active);

        private void FixedUpdate()
        {
            Vector2 velocity = characterPhysics.Velocity;

            if (Controller.IsInteractionPressed)
            {
                characterPhysics.TryInteract();
            }

            if (velocity == Vector2.zero)
            {
                Animator.Idle();
            }
            else
            {
                Animator.Walk();
            }

            Animator.Update();
            characterPhysics.Move(Controller.Move * Data.WalkSpeed);
        }

        public void Posses(CharacterController characterController)
        {
            Controller = characterController;
        }

        private void OnDrawGizmosSelected()
        {
            if (!Application.isPlaying)
                return;

            characterPhysics.DrawGizmos();
        }
    }
}