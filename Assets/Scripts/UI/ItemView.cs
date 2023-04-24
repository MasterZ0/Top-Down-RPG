using UnityEngine;
using TD.Items;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TD.UI
{
    public class ItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerDownHandler
    {
        [SerializeField] private ItemType itemType;
        [SerializeField] private Image itemIcon;
        [SerializeField] private CanvasGroup canvasGroup;

        public ItemType ItemType => itemType;

        private EquipmentWindow controller;
        public ItemData Item { get; private set; }
        private ItemSlot slot;

        public void Init(ItemData item, ItemSlot itemSlot, EquipmentWindow controller)
        {
            slot = itemSlot;
            Item = item;
            this.controller = controller;

            itemIcon.sprite = item.Icon;
            itemIcon.color = Color.white;

            itemSlot.SetItemViewWithoutNotification(this);
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
            Canvas parentCanvas = GetComponentInParent<Canvas>();
            transform.SetParent(parentCanvas.transform);
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = Input.mousePosition;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (eventData.pointerEnter != null)
            {
                ItemSlot otherSlot;
                ItemView otherView = eventData.pointerEnter.GetComponent<ItemView>();

                if (otherView != null)
                {
                    otherSlot = otherView.slot;
                    Replace(this, slot, otherView, otherSlot);
                }
                else
                {
                    otherSlot = eventData.pointerEnter.GetComponent<ItemSlot>();

                    if (otherSlot != null && slot != otherSlot)
                    {
                        otherView = otherSlot.ItemView;
                        Replace(this, slot, otherView, otherSlot);
                    }
                }
            }

            transform.position = slot.transform.position;
            transform.SetParent(slot.transform);

            canvasGroup.blocksRaycasts = true;
        }

        private static void Replace(ItemView itemView, ItemSlot currentSlot, ItemView otherView, ItemSlot otherSlot)
        {
            if (otherSlot.CanDrop(itemView) && currentSlot.CanDrop(otherView))
            {
                // Swap the item views between the two slots
                currentSlot.SetItemView(otherView);
                otherSlot.SetItemView(itemView);

                // Update the slot references of the item views
                itemView.slot = otherSlot;

                if (otherView != null)
                {
                    otherView.slot = currentSlot;
                    otherView.transform.position = otherView.slot.transform.position;
                    otherView.transform.SetParent(otherView.slot.transform);
                }
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            controller.OnSelectItem(this);
        }
    }
}