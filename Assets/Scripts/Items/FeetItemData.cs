using BG.Shared;
using UnityEngine;

namespace BG.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Feet", fileName = "New" + nameof(FeetItemData))]
    public class FeetItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Feet;

    }
}
    