using TD.Character;
using UnityEngine;

namespace TD.AI
{
    using CharacterController = Character.CharacterController;

    public class BasicNPC : CharacterController, IInteractable
    {
        [Header("Basic NPC")]
        [SerializeField] private float idleDuration = 2f;
        [Space]
        [SerializeField] private Transform[] points;
        [Space]
        [SerializeField] protected GameObject popup;

        public override Vector2 Move => move.normalized;

        protected CharacterPawn character;
        private Vector2 move;

        private float idleTime;
        private int currentIndex;
        private bool moving = true;

        private void FixedUpdate()
        {
            if (!moving)
                return;

            // Idle
            if (idleTime > 0)
            {
                idleTime -= Time.fixedDeltaTime;
                return;
            }

            // Walk 
            move = (Vector2)points[currentIndex].position - pawn.Physics.Position;

            if (Vector2.Distance(pawn.Physics.Position, points[currentIndex].position) < 0.1f)
            {
                move = Vector2.zero;
                idleTime = idleDuration;

                currentIndex++;
                if (currentIndex >= points.Length)
                {
                    currentIndex = 0;
                }
            }
        }

        public bool OnInteract(CharacterPawn character)
        {
            popup.SetActive(true);

            character.SetActiveController(false);
            this.character = character;

            moving = false;
            move = Vector2.zero;
            Vector2 direction = character.transform.position - transform.position;
            pawn.Physics.LookAt(direction);

            return true;
        }

        public void OnInteractionEnd()
        {
            moving = true;

            popup.SetActive(false);

            character.SetActiveController(true);
        }
    }
}