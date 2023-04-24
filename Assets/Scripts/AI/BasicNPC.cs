using UnityEngine;

namespace TD.AI
{
    using CharacterController = Character.CharacterController;

    public class BasicNPC : CharacterController
    {
        [Header("Basic NPC")]
        [SerializeField] private float idleDuration = 2f;
        [Space]
        [SerializeField] private Transform[] points;

        public override Vector2 Move => move.normalized;

        protected Vector2 move;

        private float idleTime;
        private int currentIndex;
        protected bool moving = true;

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
            move = points[currentIndex].position - transform.position;

            if (Vector2.Distance(transform.position, points[currentIndex].position) < 0.1f)
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
    }
}