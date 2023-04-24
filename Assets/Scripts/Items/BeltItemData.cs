using TD.Shared;
using UnityEngine;

namespace TD.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Belt", fileName = "New" + nameof(BeltItemData))]
    public class BeltItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Belt;

    }
}
    