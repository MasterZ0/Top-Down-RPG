using System.Collections.Generic;
using UnityEngine;
using Z3.ObjectPooling;
using TD.Inputs;
using TD.Character;
using TD.UI.Window;
using TD.Items;

namespace TD.UI
{
    /// <summary>
    /// Controla os slots e o selector apenas
    /// </summary>
    public class EquipmentWindow : SimpleWindow
    {
        [Header("Equipment Screen")]
        //[SerializeField] private UISounds uiSounds;
        [SerializeField] private ItemInfoPanel itemInfoPanel;
        [SerializeField] private RectTransform inventorySlotsContainer;

        [Header("Build")]
        [SerializeField] private List<ItemSlot> equipmentSlots = new List<ItemSlot>();

        [Header("Prefabs")]
        [SerializeField] private ItemView itemView;
        [SerializeField] private ItemSlot itemSlot;

        private CharacterInventoryController Inventory => pawn.Inventory;


        private List<ItemView> itemViewList = new();
        private List<ItemSlot> inventorySlots = new();

        private UIInputs inputs;
        private CharacterPawn pawn;

        public void Init(CharacterPawn pawn)
        {
            this.pawn = pawn;

            inputs = new UIInputs(false);
            inputs.OnInventory += (pressed) => { if (pressed) CloseWindow(); };
            inputs.OnCancel += (pressed) => { if (pressed) CloseWindow(); };

            int count = Inventory.GetSlotsCount();

            // Create Bag slots
            for (int i = 0; i < count; i++)
            {
                ItemSlot newItemView = ObjectPool.SpawnPooledObject(itemSlot, inventorySlotsContainer);
                newItemView.InitAsStore(i, this);
                inventorySlots.Add(newItemView);
            }

            // Setup Equipment slots
            foreach (ItemSlot itemSlot in equipmentSlots)
            {
                itemSlot.SetOwner(this);
            }
        }

        public override void OpenWindow()
        {
            // Fill Equipments
            foreach (ItemSlot slot in equipmentSlots)
            {
                ItemData item = Inventory.GetEquippedItem(slot.SlotType);
                if (item != null)
                {
                    ItemView newItemView = ObjectPool.SpawnPooledObject(itemView, slot.transform.position, Quaternion.identity, slot.transform);
                    newItemView.Init(item, slot, this);
                    itemViewList.Add(newItemView);
                }
                else
                {
                    slot.SetItemViewWithoutNotification(null);
                }
            }

            // Fill Inventory
            List<ItemData> items = Inventory.GetStored();
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (items[i] != null)
                {
                    ItemView newItemView = ObjectPool.SpawnPooledObject(itemView, inventorySlots[i].transform.position, Quaternion.identity, inventorySlots[i].transform);
                    newItemView.Init(items[i], inventorySlots[i], this);
                    itemViewList.Add(newItemView);
                }
                else
                {
                    inventorySlots[i].SetItemViewWithoutNotification(null);
                }
            }

            itemInfoPanel.ShowItem(null);

            inputs.SetActive(true);
            pawn.SetActiveController(false);

            base.OpenWindow();
        }

        public void OnSelectItem(ItemView itemView) => itemInfoPanel.ShowItem(itemView.Item);

        public override void CloseWindow()
        {
            base.CloseWindow();

            // Clean Equipments and Inventory
            foreach (ItemView itemView in itemViewList)
            {
                itemView.ReturnToPool();
            }

            itemViewList.Clear();

            inputs.SetActive(false);
            pawn.SetActiveController(true);
        }

        public void SetSlot(ItemData item, SlotType slotType, int index)
        {
            if (slotType == SlotType.Store)
            {
                Inventory.SetStorage(item, index);
                return;
            }

            Inventory.SetEquippedItem(item, slotType);
        }
    }
}