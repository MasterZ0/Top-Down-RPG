using TD.Shared;
using UnityEngine;

namespace TD.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Feet", fileName = "New" + nameof(FeetItemData))]
    public class FeetItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Feet;

    }
}
    