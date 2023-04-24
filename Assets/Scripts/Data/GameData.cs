using TD.Shared;
using UnityEngine;

namespace TD.Data
{
    [CreateAssetMenu(menuName = MenuPath.Data + "GameData", fileName = "New" + nameof(GameData))]
    public class GameData : ScriptableObject 
    {
        [Header("GameData")]
        [SerializeField] private Material defaultMaterial;

        public static Material DefaultMaterial => Instance.defaultMaterial;
        private static GameData Instance { get; set; }

        public void Init()
        {
            Instance = this;
        }
    }
}