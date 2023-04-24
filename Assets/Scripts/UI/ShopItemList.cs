using UnityEngine;
using TMPro;
using BG.Items;
using UnityEngine.UI;

namespace BG.UI
{
    public class ShopItemList : MonoBehaviour
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text itemName;
        [SerializeField] private TMP_Text price;

        public ItemData Item { get; private set; }
        private ShopScreen shopScreen;

        internal void Setup(PurchaseScreen shopScreen, ItemData item)
        {
            this.shopScreen = shopScreen;
            Item = item;

            itemName.text = item.ItemName;
            price.text = item.SellingPrice.ToString();
            icon.sprite = item.Icon;
        }

        internal void Setup(SaleScreen shopScreen, ItemData item)
        {
            this.shopScreen = shopScreen;
            Item = item;

            itemName.text = item.ItemName;
            icon.sprite = item.Icon;
        }

        public void OnSubmit()
        {
            shopScreen.SelectListItem(this);
        }

        internal void UpdatePriceColor(int playerGold)
        {
            bool cabBuy = playerGold >= Item.BuyPrice;

            price.text = $"{Item.BuyPrice}";
            price.color = cabBuy ? Color.white : Color.red;
        }
    }
}