using UnityEngine;
using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;
using Z3.ObjectPooling;

namespace TD.Items
{
    [System.Serializable]
    public class ModelController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform itemContainer;
        [Space]
        [SerializeField] private Animator hair;
        [SerializeField] private Animator body;

        private Dictionary<ItemType, SpriteController> items = new();

        public void SetDefaultInventory(Inventory defaultInventory)
        {
            TryCreate(defaultInventory.Head);
            TryCreate(defaultInventory.Torso);
            TryCreate(defaultInventory.Hands);
            TryCreate(defaultInventory.Belt);
            TryCreate(defaultInventory.Legs);
            TryCreate(defaultInventory.Feet);
        }

        private void TryCreate(ItemData item)
        {
            if (item == null)
                return;

            SetItem(item, item.ItemType);
        }

        public void SetItem(ItemData item, ItemType itemType)
        {
            if (items.TryGetValue(itemType, out SpriteController spriteController))
            {
                items.Remove(itemType);
                spriteController.ReturnToPool();
            }

            if (item == null)
                return;

            SpriteController newItem = ObjectPool.SpawnPooledObject(item.Prefab, itemContainer.position, Quaternion.identity, itemContainer);
            newItem.Setup(item);
            items.Add(itemType, newItem);
        }

        public void Play(string stateName)
        {
            hair.Play(stateName);
            body.Play(stateName);

            foreach (SpriteController spriteController in items.Values)
            {
                spriteController.Play(stateName);
            }
        }

        public void SetFloat(string parameter, float value)
        {
            hair.SetFloat(parameter, value);
            body.SetFloat(parameter, value); 
            
            foreach (SpriteController spriteController in items.Values)
            {
                spriteController.SetFloat(parameter, value);
            }
        }
    }
}