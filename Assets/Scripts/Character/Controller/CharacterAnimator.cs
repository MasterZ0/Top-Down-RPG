using TD.Items;
using System;
using UnityEngine;

namespace TD.Character
{
    [Serializable]
    public sealed class CharacterAnimator : CharacterControllerComponent
    {
        [Header("Character Animator")]
        [SerializeField] private string idleState = "Idle";
        [SerializeField] private string walkState = "Walk";

        private ModelController ModelController => Controller.ModelController;

        internal void Update()
        {
            Vector2 velocity = Controller.Physics.Direction;

            ModelController.SetFloat("X", velocity.x);
            ModelController.SetFloat("Y", velocity.y);
        }

        internal void Idle() => Play(idleState);
        internal void Walk() => Play(walkState);

        private void Play(string stateName) => ModelController.Play(stateName);
    }
}