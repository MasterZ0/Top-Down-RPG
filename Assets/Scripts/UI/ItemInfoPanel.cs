using UnityEngine;
using TMPro;
using TD.Items;
using UnityEngine.UI;

namespace TD.UI
{
    public class ItemInfoPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text itemDescription;
        [SerializeField] private Image itemIcon;

        public ItemData CurrentItem { get; private set; }

        public void ShowItem(ItemData item)
        {
            CurrentItem = item;

            if (item == null)
            {
                itemName.text = string.Empty;
                itemDescription.text = string.Empty;
                itemIcon.transform.parent.gameObject.SetActive(false);
                return;
            }

            itemName.text = item.ItemName;
            itemDescription.text = item.ItemDescription;
            itemIcon.sprite = item.Icon;

            itemIcon.transform.parent.gameObject.SetActive(true);
        }
    }
}