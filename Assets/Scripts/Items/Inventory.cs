using System.Collections.Generic;

namespace TD.Items
{
    public class Inventory
    {
        public HeadItemData Head { get; set; }
        public TorsoItemData Torso { get; set; }
        public BeltItemData Belt { get; set; }
        public HandsItemData Hands { get; set; }
        public LegsItemData Legs { get; set; }
        public FeetItemData Feet { get; set; }

        public int Gold { get; set; }

        public readonly List<ItemData> storedItems;

        public Inventory(int storageCapacity, DefaultInventory defaultInventory)
        {
            storedItems = new(storageCapacity);

            for (int i = 0; i < storageCapacity; i++)
            {
                storedItems.Add(null);
            }

            Gold = defaultInventory.gold;
            Head = defaultInventory.head;
            Torso = defaultInventory.torso;
            Belt = defaultInventory.belt;
            Hands = defaultInventory.hands;
            Legs = defaultInventory.legs;
            Feet = defaultInventory.feet;
        }
    }
}