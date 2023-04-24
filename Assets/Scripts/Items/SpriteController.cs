using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BG.Items
{
    public class SpriteController : MonoBehaviour
    {
        [SerializeField] private List<SpriteRenderer> spriteRenderers;
        [SerializeField] private List<Animator> animators;

        public ItemData Item { get; private set; }

        private void Reset()
        {
            animators = GetComponentsInChildren<Animator>().ToList();
        }

        public void Setup(ItemData item)
        {
            Item = item;
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

        private void SetMaterial(Material material)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.material = material;
            }
        }
    }
}
    