using BG.Shared;
using UnityEngine;

namespace BG.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Head", fileName = "New" + nameof(HeadItemData))]
    public class HeadItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Head;
    }
}
    