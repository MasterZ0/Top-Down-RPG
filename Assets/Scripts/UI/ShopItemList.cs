using UnityEngine;
using TMPro;
using TD.Items;
using UnityEngine.UI;

namespace TD.UI
{
    public class ShopItemList : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text price;

        public ItemData Item { get; private set; }
        private ShopWindow shopScreen;

        internal void Setup(SaleWindow shopScreen, ItemData item)
        {
            this.shopScreen = shopScreen;
            Item = item;

            itemName.text = item.ItemName;
            price.text = item.SellingPrice.ToString();
            icon.sprite = item.Icon;
            price.color = Color.white;
        }

        internal void Setup(PurchaseWindow shopScreen, ItemData item)
        {
            this.shopScreen = shopScreen;
            Item = item;

            itemName.text = item.ItemName;
            icon.sprite = item.Icon;
        }

        internal void UpdatePriceColor(int playerGold)
        {
            bool cabBuy = playerGold >= Item.BuyPrice;

            price.text = $"{Item.BuyPrice}";
            price.color = cabBuy ? Color.white : Color.red;
        }

        public void OnSubmit()
        {
            shopScreen.SelectListItem(this);
        }
    }
}