using TD.Shared;
using UnityEngine;

namespace TD.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Torso", fileName = "New" + nameof(TorsoItemData))]
    public class TorsoItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Torso;

    }
}
    