using BG.Shared;
using UnityEngine;

namespace BG.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Hand", fileName = "New" + nameof(HandsItemData))]
    public class HandsItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Hands;

    }
}
    