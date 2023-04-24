using UnityEngine;
using TD.Character;
using TD.UI;
using TD.UI.Window;
using TD.Items;
using System.Collections.Generic;

namespace TD.AI
{
    public class Merchant : BasicNPC
    {
        [Header("Merchant")]
        [SerializeField] private SaleWindow saleScreen;
        [SerializeField] private PurchaseWindow purchaseScreen;
        [SerializeField] private List<ItemData> itemsToSell;

        public void OnOpenPurchase()
        {
            popup.SetActive(false);

            WindowManager.OnCloseLastWindow += OnCloseLastWindow;
            purchaseScreen.SetItemsToSell(itemsToSell);
            purchaseScreen.OpenStore(character.Inventory);
        }

        public void OnOpenSales()
        {
            popup.SetActive(false);

            WindowManager.OnCloseLastWindow += OnCloseLastWindow;
            saleScreen.OpenStore(character.Inventory);
        }

        private void OnCloseLastWindow()
        {
            WindowManager.OnCloseLastWindow -= OnCloseLastWindow;
            popup.SetActive(true);
        }
    }
}