using TD.Shared;
using UnityEngine;

namespace TD.Items
{
    [CreateAssetMenu(menuName = MenuPath.Data + "Default Inventory", fileName = "New" + nameof(DefaultInventory))]
    public class DefaultInventory : ScriptableObject
    {
        public int gold;
        public HeadItemData head;
        public TorsoItemData torso;
        public LegsItemData legs;
        public HandsItemData hands;
        public FeetItemData feet;
        public BeltItemData belt;
    }
}