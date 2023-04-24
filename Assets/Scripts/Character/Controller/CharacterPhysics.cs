using UnityEngine;
using System;

namespace TD.Character
{
    /// <summary>
    /// Handles Character physics
    /// </summary>
    [Serializable]
    public sealed class CharacterPhysics : CharacterControllerComponent
    {
        [Header("Layers")]
        [SerializeField] private LayerMask interactableLayer;

        [Header("Components")]
        [SerializeField] private Rigidbody2D rigidbody;

        [Header("Points")]
        [SerializeField] private Transform interactableCheckPoint;

        public Vector3 Velocity => rigidbody.velocity;
        public Transform Transform => rigidbody.transform;

        public Vector2 Direction { get; private set; } = Vector2.down;

        public void Move(Vector2 velocity)
        {
            rigidbody.velocity = velocity;

            LookAt(velocity);
        }

        public void LookAt(Vector2 direction)
        {
            if (direction == Vector2.zero)
                return;

            if (Mathf.Abs(direction.y) > Mathf.Abs(direction.x))
            {
                Direction = direction.y > 0 ? Vector2.up : Vector2.down;
            }
            else
            {
                Direction = direction.x > 0 ? Vector2.right : Vector2.left;
            }
        }

        internal void TryInteract()
        {
            Vector2 point = (Vector2)Transform.position + Direction * Data.InteractionOffset;
            Collider2D[] cols = Physics2D.OverlapCircleAll(point, Data.InteractCheckRadius, interactableLayer);

            foreach (Collider2D col in cols)
            {
                if (col && col.attachedRigidbody && col.attachedRigidbody.TryGetComponent(out IInteractable interactable))
                {
                    interactable.OnInteract(Controller);
                    return;
                }

            }
        }

        public void DrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Vector2 point = (Vector2)Transform.position + Direction * Data.InteractionOffset;
            Gizmos.DrawWireSphere(point, Data.InteractCheckRadius);
        }
    }
}