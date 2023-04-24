using System.Collections.Generic;
using TD.Character;
using TD.UI.Window;
using UnityEngine;

namespace TD.UI
{
    public abstract class ShopWindow : SimpleWindow
    {
        [SerializeField] protected GoldCounter goldCounter;

        protected CharacterInventoryController Inventory { get; private set; }

        public void OpenStore(CharacterInventoryController characterInventory)
        {
            Inventory = characterInventory;
            goldCounter.UpdateGold(characterInventory);

            OnRequestToOpen();
            OpenStore();
        }

        public abstract void SelectListItem(ShopItemList itemList);

        protected abstract void OpenStore();
    }
}