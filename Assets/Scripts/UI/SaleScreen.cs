using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System;
using BG.Items;
using Z3.ObjectPooling;

namespace BG.UI
{
    /// <summary>
    /// Where the player buys new items
    /// </summary>
    public class SaleScreen : ShopScreen
    {
        [Header("Store Screen")]
        [SerializeField] private ItemInfoPanel itemInfoPanel;
        [SerializeField] private Transform scrollContent;

        [Header("SFX")]
        //[SerializeField] private UISounds uiSounds;
        //[SerializeField] private SoundReference confirmedPurchase;
        //[SerializeField] private SoundReference purchaseNotAllowed;

        [Header("Prefabs")]
        [SerializeField] private ShopItemList listShopItem;

        private readonly List<ShopItemList> list = new();

        public void SetItemsToSell(List<ItemData> itemsToSell)
        {
            List<ItemData> itemsForSale = itemsToSell
                .OrderBy(i => i.BuyPrice)              // Order By Price
                .OrderBy(i => i.GetType().Name)        // Order By Type
                .ToList();

            foreach (ItemData item in itemsForSale)
            {
                ShopItemList newItemList = ObjectPool.SpawnPooledObject(listShopItem, scrollContent);

                newItemList.Setup(this, item);

                list.Add(newItemList);
            }
        }

        protected override void OpenStore()
        {
            //openShopSound.PlaySound();
            UpdatePlayerGold();

            itemInfoPanel.ShowItem(list[0].Item);
        }

        private void UpdatePlayerGold()
        {
            foreach (ShopItemList itemList in list)
            {
                itemList.UpdatePriceColor(Inventory.Gold);
            }
        }

        public override void SelectListItem(ShopItemList itemList)
        {
            itemInfoPanel.ShowItem(itemList.Item);
        }

        public void OnBuyItem()
        {
            ItemData currentItem = itemInfoPanel.CurrentItem;

            if (Inventory.Gold < currentItem.BuyPrice && Inventory.HasEmptySlot())
                return;
            //purchaseNotAllowed.PlaySound();

            Inventory.AddItem(currentItem);

            Inventory.RemoveGold(currentItem.BuyPrice);

            UpdatePlayerGold();

            //confirmedPurchase.PlaySound();
        }

        internal void OpenStore(object inventory)
        {
            throw new NotImplementedException();
        }
    }
}