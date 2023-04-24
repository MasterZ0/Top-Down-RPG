using TD.Shared;
using UnityEngine;

namespace TD.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Hand", fileName = "New" + nameof(HandsItemData))]
    public class HandsItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Hands;

    }
}
    