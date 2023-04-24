using UnityEngine;

namespace BG.Items
{
    public enum ItemType
    {
        Head,
        Torso,
        Hands,
        Belt,
        Legs,
        Feet,
        //PrimaryWeapon,
        //SecondaryWeapon,
        //Ring,
        //Amulet,
        //Consumable,
        //Arrow
    }

    /// <summary>
    /// Note to developers: Please describe what this class does.
    /// </summary>
    public abstract class ItemData : ScriptableObject
    {
        //[Title("ItemData")]
        [SerializeField] private SpriteController prefab;
        [SerializeField] private Material material;
        [SerializeField] private Sprite icon;
        [Space]
        [SerializeField] private int sellingPrice;
        [SerializeField] private int buyPrice;
        [SerializeField] private string itemName;
        [SerializeField] private string itemDescription;

        public string ItemName => !string.IsNullOrEmpty(itemName) ? itemName : name;
        public string ItemDescription => itemDescription;
        public SpriteController Prefab => prefab;
        public Material Material => material;
        public Sprite Icon => icon;
        public abstract ItemType ItemType { get; }
        public int SellingPrice => sellingPrice;
        public int BuyPrice => buyPrice;
    }
}
    