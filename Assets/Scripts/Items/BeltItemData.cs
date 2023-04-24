using BG.Shared;
using UnityEngine;

namespace BG.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Belt", fileName = "New" + nameof(BeltItemData))]
    public class BeltItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Belt;

    }
}
    