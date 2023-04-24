using UnityEngine;
using BG.Character;
using BG.UI;
using BG.UI.Window;
using BG.Items;
using System.Collections.Generic;

namespace BG.AI
{
    public class Merchant : BasicNPC, IInteractable
    {
        [Header("Merchant")]
        [SerializeField] private GameObject questionPopup;
        [SerializeField] private SaleScreen saleScreen;
        [SerializeField] private PurchaseScreen purchaseScreen;
        [SerializeField] private List<ItemData> itemsToSell;

        private CharacterPawn character;

        private void Start()
        {
            saleScreen.SetItemsToSell(itemsToSell);
        }

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