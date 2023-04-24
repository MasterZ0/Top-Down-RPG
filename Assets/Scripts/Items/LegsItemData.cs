using TD.Shared;
using UnityEngine;

namespace TD.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Legs", fileName = "New" + nameof(LegsItemData))]
    public class LegsItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Legs;

    }
}
    