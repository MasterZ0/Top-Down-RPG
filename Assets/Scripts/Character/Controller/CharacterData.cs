//using AdventureGame.Shared;
using TD.Shared;
using UnityEngine;

namespace TD.Data
{
    [CreateAssetMenu(menuName = MenuPath.Data + "Character", fileName = "New" + nameof(CharacterData))]
    public class CharacterData : ScriptableObject
    {
        [Header("Physics")]
        [SerializeField] private float interactCheckRadius = 0.3f;
        [SerializeField] private float interactionOffset = 0.5f;

        [Header(" - Movement")]
        [SerializeField] private float walkSpeed = 1f;
        [SerializeField] private float runSpeed = 6f;

        public float WalkSpeed => walkSpeed;
        public float InteractCheckRadius => interactCheckRadius;
        public float InteractionOffset => interactionOffset;
    }
}