namespace TD.Items
{
    public enum SlotType
    {
        Store,
        Head,
        Amulet,
        Torso,
        Hands,
        Belt,
        Legs,
        Feet,
        LeftRing,
        RightRing,
        PrimaryWeapon,
        SecondaryWeapon,
        Arrow,
        Consumable
    }

    public static class SlotExtension
    {
        public static bool CompareType(this SlotType slotType, ItemType itemType)
        {
            if (slotType == SlotType.Store)
                return true;

            return itemType.ConvertType() == slotType;
        }

        public static SlotType ConvertType(this ItemType slotType)
        {
            return slotType switch
            {
                ItemType.Head => SlotType.Head,
                ItemType.Torso => SlotType.Torso,
                ItemType.Hands => SlotType.Hands,
                ItemType.Belt => SlotType.Belt,
                ItemType.Legs => SlotType.Legs,
                ItemType.Feet => SlotType.Feet,
                _ => throw new System.NotImplementedException(),
            };
        }

        public static bool TryConvertType(this SlotType slotType, out ItemType outItemType)
        {
            ItemType? itemType = slotType.ConvertType();
            if (itemType.HasValue)
            {
                outItemType = itemType.Value;
                return true;
            }

            outItemType = default;
            return false;
        }

        public static ItemType? ConvertType(this SlotType slotType)
        {
            return slotType switch
            {
                SlotType.Head => ItemType.Head,
                SlotType.Torso => ItemType.Torso,
                SlotType.Hands => ItemType.Hands,
                SlotType.Belt => ItemType.Belt,
                SlotType.Legs => ItemType.Legs,
                SlotType.Feet => ItemType.Feet,
                _ => null,
            };
        }
    }
}