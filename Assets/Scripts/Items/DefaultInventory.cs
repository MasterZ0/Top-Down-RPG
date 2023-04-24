using BG.Shared;
using UnityEngine;

namespace BG.Items
{
    [CreateAssetMenu(menuName = MenuPath.Data + "Default Inventory", fileName = "New" + nameof(DefaultInventory))]
    public class DefaultInventory : ScriptableObject
    {
        public HeadItemData head;
        public TorsoItemData torso;
        public LegsItemData legs;
        public HandsItemData hands;
        public FeetItemData feet;
        public BeltItemData belt;
    }
}