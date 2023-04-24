using TD.Items;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TD.UI
{

    public class ItemSlot : MonoBehaviour, IDropHandler
    {
        [SerializeField] private SlotType slotType;

        public SlotType SlotType => slotType;
        public ItemView ItemView { get; private set; }

        private EquipmentWindow controller;
        private int index = -1;

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
            ItemView = itemView;
        }

        public void SetItemView(ItemView itemView)
        {
            ItemView = itemView;
            ItemData item = itemView ? itemView.Item : null;
            controller.SetSlot(item, slotType, index);
        }

        public bool CanDrop(ItemView itemView) => itemView == null || slotType.CompareType(itemView.Item.ItemType);

        public void OnDrop(PointerEventData eventData) { }
    }
}