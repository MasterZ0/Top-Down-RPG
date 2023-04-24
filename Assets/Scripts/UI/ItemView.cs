using UnityEngine;
using BG.Items;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BG.UI
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
                ItemSlot itemSlot = eventData.pointerEnter.GetComponent<ItemSlot>();
                if (itemSlot != null && slot != itemSlot && itemSlot.CanDrop(this))
                {
                    slot.SetItemView(null);
                    slot = itemSlot;
                    slot.SetItemView(this);
                }
            }

            canvasGroup.blocksRaycasts = true;
            transform.SetParent(slot.transform);
            transform.position = slot.transform.position;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            controller.OnSelectItem(this);
        }
    }
}