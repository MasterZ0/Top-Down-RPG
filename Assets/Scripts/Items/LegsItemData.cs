using BG.Shared;
using UnityEngine;

namespace BG.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Legs", fileName = "New" + nameof(LegsItemData))]
    public class LegsItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Legs;

    }
}
    