using BG.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BG.UI
{

    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private SlotType slotType;

        public SlotType SlotType => slotType;

        private ItemView itemView;
        private int index = -1;

        private EquipmentWindow controller;

        internal void InitAsStore(int index, EquipmentWindow controller)
        {
            this.controller = controller;
            this.index = index;
            slotType = SlotType.Store;
        }

        internal void SetOwner(EquipmentWindow controller)
        {
            this.controller = controller;
        }

        public void SetItemViewWithoutNotification(ItemView itemView)
        {
            this.itemView = itemView;
        }

        public void SetItemView(ItemView itemView)
        {
            this.itemView = itemView;
            ItemData item = itemView ? itemView.Item : null;
            controller.SetSlot(item, slotType, index);
        }

        public bool CanDrop(ItemView itemView) => this.itemView == null && slotType.CompareType(itemView.Item.ItemType);

        public void OnDrop(PointerEventData eventData) { }
    }
}