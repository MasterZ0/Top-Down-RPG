using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TD.Items
{
    public class SpriteController : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> spriteRenderers;
        [SerializeField] private List<Animator> animators;

        public ItemData Item { get; private set; }
        private Material defaultMaterial;

        private void Awake()
        {
            defaultMaterial = spriteRenderers[0].material;
        }

        private void Reset()
        {
            animators = GetComponentsInChildren<Animator>().ToList();
        }

        public void Setup(ItemData item)
        {
            Item = item;

            Material material = item.Material ? item.Material : defaultMaterial;
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.material = material;
            }
        }

        public void Play(string clipName)
        {
            foreach (Animator animator in animators)
            {
                animator.Play(clipName);
            }
        }

        public void SetFloat(string parameter, float value)
        {
            foreach (Animator animator in animators)
            {
                animator.SetFloat(parameter, value);
            }
        }
    }
}
    