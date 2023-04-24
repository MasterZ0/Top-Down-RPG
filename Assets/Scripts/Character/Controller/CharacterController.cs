using System;
using UnityEngine;
namespace TD.Character
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] protected CharacterPawn pawn;

        public event Action OnInteractionTrue { add => interaction.OnValueTrue += value; remove => interaction.OnValueTrue -= value; }
        public event Action OnInteractionFalse { add => interaction.OnValueFalse += value; remove => interaction.OnValueFalse -= value; }

        public event Action OnSprintTrue { add => interaction.OnValueTrue += value; remove => interaction.OnValueTrue -= value; }
        public event Action OnSprintFalse { add => interaction.OnValueFalse += value; remove => interaction.OnValueFalse -= value; }

        public virtual Vector2 Move { get; }
        public bool IsInteractionPressed { get => interaction.Value; protected set => interaction.Set(value); }
        public bool IsSprintPressed { get => sprint.Value; protected set => sprint.Set(value); }

        private readonly BoolSetter sprint = new();
        private readonly BoolSetter interaction = new();

        protected virtual void Awake()
        {
            pawn.Posses(this);
        }

        public virtual void OnSetActive(bool active) { }
    }
}