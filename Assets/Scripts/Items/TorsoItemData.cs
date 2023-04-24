using BG.Shared;
using UnityEngine;

namespace BG.Items
{
    [CreateAssetMenu(menuName = MenuPath.Items + "Torso", fileName = "New" + nameof(TorsoItemData))]
    public class TorsoItemData : ItemData
    {
        public override ItemType ItemType => ItemType.Torso;

    }
}
    