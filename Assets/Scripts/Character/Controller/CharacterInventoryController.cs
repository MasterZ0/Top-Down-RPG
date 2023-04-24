using TD.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TD.Character
{
    [Serializable]
    public class CharacterInventoryController : CharacterControllerComponent
    {
        [SerializeField] private int bagStorageCapacity = 30;

        public int Gold { get => Inventory.Gold; private set => Inventory.Gold = value; }
        private ModelController ModelController => Controller.ModelController;
        private List<ItemData> StoredItems => Inventory.storedItems;

        private Inventory Inventory;

        public override void Init(CharacterPawn controller)
        {
            base.Init(controller);
            Inventory = new(bagStorageCapacity, Controller.DefaultInventory);
            ModelController.SetDefaultInventory(Inventory);
        }

        public void AddGold(int gold)
        {
            Gold += gold;
        }

        public bool RemoveGold(int gold)
        {
            if (Gold - gold < 0)
                return false;

            Gold -= gold;
            return true;
        }

        public bool HasEmptySlot() => StoredItems.Any(i => i == null);

        public bool AddItem(ItemData item)
        {
            for (int i = 0; i < StoredItems.Count; i++)
            {
                if (StoredItems[i] == null)
                {
                    StoredItems[i] = item;
                    return true;
                }
            }
            return false;
        }

        public void RemoveItem(ItemData item)
        {
            int index = StoredItems.IndexOf(item);
            StoredItems[index] = null;
        }

        public List<ItemData> GetStoredItems()
        {
            return StoredItems.Where(i => i != null).ToList();
        }

        public List<ItemData> GetStored()
        {
            return StoredItems;
        }

        public void SetStorage(ItemData item, int index)
        {
            StoredItems[index] = item;
        }

        public void SetEquippedItem(ItemData item, SlotType slotType)
        {
            switch (slotType)
            {
                case SlotType.Head:
                    Inventory.Head = (HeadItemData)item;
                    break;
                case SlotType.Torso:
                    Inventory.Torso = (TorsoItemData)item;
                    break;
                case SlotType.Hands:
                    Inventory.Hands = (HandsItemData)item;
                    break;
                case SlotType.Belt:
                    Inventory.Belt = (BeltItemData)item;
                    break;
                case SlotType.Legs:
                    Inventory.Legs = (LegsItemData)item;
                    break;
                case SlotType.Feet:
                    Inventory.Feet = (FeetItemData)item;
                    break;
                default:
                    throw new NotImplementedException();
            }

            if (slotType.TryConvertType(out ItemType itemType))
            {
                ModelController.SetItem(item, itemType);
            }
        }

        public ItemData GetEquippedItem(SlotType itemType)
        {
            return itemType switch
            {
                SlotType.Head => Inventory.Head,
                SlotType.Torso => Inventory.Torso,
                SlotType.Hands => Inventory.Hands,
                SlotType.Belt => Inventory.Belt,
                SlotType.Legs => Inventory.Legs,
                SlotType.Feet => Inventory.Feet,
                _ => throw new NotImplementedException(),
            };
        }

        public int GetSlotsCount() => StoredItems.Capacity;
    }
}