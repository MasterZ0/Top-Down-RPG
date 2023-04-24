using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using BG.Items;
using Z3.ObjectPooling;

namespace BG.UI
{
    /// <summary>
    /// Where your own player sells the items
    /// </summary>
    public class PurchaseScreen : ShopScreen
    {
        [Header("Store Screen")]
        [SerializeField] private ItemInfoPanel itemInfoPanel;
        [SerializeField] private Transform scrollContent;

        [Header("SFX")]
        //[SerializeField] private UISounds uiSounds;
        //[SerializeField] private SoundReference confirmedPurchase;

        [Header("Prefabs")]
        [SerializeField] private ShopItemList listShopItem;

        private readonly List<ShopItemList> list = new List<ShopItemList>();


        private ShopItemList currentSelection;

        protected override void OpenStore()
        {
            // Create item list
            List<ItemData> itemsForSale = Inventory.GetStoredItems()
                .OrderBy(i => i.SellingPrice)          // Order By Price
                .OrderBy(i => i.GetType().Name)        // Order By Type
                .ToList();

            foreach (ItemData item in itemsForSale)
            {
                ShopItemList newItemList = ObjectPool.SpawnPooledObject(listShopItem, scrollContent);

                newItemList.Setup(this, item);

                list.Add(newItemList);
            }

            if (list.Count > 0)
            {
                currentSelection = list[0];
                itemInfoPanel.ShowItem(currentSelection.Item);
            }
            else
            {
                currentSelection = null;
                itemInfoPanel.ShowItem(null);
            }
        }

        private void OnDisable()
        {
            foreach (ShopItemList item in list)
            {
                item.ReturnToPool();
            }
            list.Clear();
        }

        public override void SelectListItem(ShopItemList itemList)
        {
            currentSelection = itemList;
            itemInfoPanel.ShowItem(itemList.Item);
        }

        public void OnSellItem()
        {
            // Try sell
            Inventory.RemoveItem(currentSelection.Item);
            
            Inventory.AddGold(currentSelection.Item.SellingPrice);

            list.Remove(currentSelection);

            currentSelection.ReturnToPool();

            itemInfoPanel.ShowItem(null);
            //confirmedPurchase.PlaySound();
        }
    }
}