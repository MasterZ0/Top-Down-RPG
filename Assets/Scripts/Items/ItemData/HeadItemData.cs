using TD.Shared;
using UnityEngine;

namespace TD.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Head", fileName = "New" + nameof(HeadItemData))]
    public class HeadItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Head;
    }
}
    