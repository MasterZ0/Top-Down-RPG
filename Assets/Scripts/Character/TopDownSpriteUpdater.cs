using UnityEngine;

namespace TD.Character
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class TopDownSpriteUpdater : MonoBehaviour
    {
        [SerializeField] private bool staticSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private int baseValue;

        private void Reset()
        {
            TryGetComponent(out spriteRenderer);
        }

        private void Awake()
        {
            baseValue = spriteRenderer.sortingOrder;

            if (staticSprite)
            {
                Update();
                enabled = false;
            }
        }

        private void Update()
        {
            spriteRenderer.sortingOrder = baseValue - Mathf.RoundToInt(transform.position.y * 1000f);
        }
    }
}
    