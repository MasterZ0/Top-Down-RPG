using UnityEngine;
using TD.Character;
using TD.UI;
using TD.UI.Window;
using TD.Items;
using System.Collections.Generic;

namespace TD.AI
{
    public class Merchant : BasicNPC, IInteractable
    {
        [Header("Merchant")]
        [SerializeField] private GameObject questionPopup;
        [SerializeField] private SaleWindow saleScreen;
        [SerializeField] private PurchaseWindow purchaseScreen;
        [SerializeField] private List<ItemData> itemsToSell;

        private CharacterPawn character;

        public bool OnInteract(CharacterPawn character)
        {
            questionPopup.SetActive(true);

            character.SetActiveController(false);
            this.character = character;

            moving = false;
            move = Vector2.zero;
            Vector2 direction = character.transform.position - transform.position;
            pawn.Physics.LookAt(direction);

            return true;
        }

        public void OnOpenPurchase()
        {
            questionPopup.SetActive(false);

            WindowManager.OnCloseLastWindow += OnCloseLastWindow;
            purchaseScreen.SetItemsToSell(itemsToSell);
            purchaseScreen.OpenStore(character.Inventory);
        }

        public void OnOpenSales()
        {
            questionPopup.SetActive(false);

            WindowManager.OnCloseLastWindow += OnCloseLastWindow;
            saleScreen.OpenStore(character.Inventory);
        }

        private void OnCloseLastWindow()
        {
            WindowManager.OnCloseLastWindow -= OnCloseLastWindow;
            questionPopup.SetActive(true);
        }

        public void OnCancelInteraction()
        {
            moving = true;

            questionPopup.SetActive(false);

            character.SetActiveController(true);
        }
    }
}