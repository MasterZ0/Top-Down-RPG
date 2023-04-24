using BG.Character;
using BG.UI.Window;

namespace BG.UI
{
    public abstract class ShopScreen : SimpleWindow
    {
        protected CharacterInventoryController Inventory { get; private set; }

        public void OpenStore(CharacterInventoryController playerInventory)
        {
            Inventory = playerInventory;

            OnRequestToOpen();
            OpenStore();
        }

        public abstract void SelectListItem(ShopItemList itemList);

        protected abstract void OpenStore();
    }
}