using UnityEngine;
using TMPro;
using TD.Character;

namespace TD.UI
{
    public class GoldCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text gold;

        private void OnEnable()
        {
            // TODO: Get Static reference
        }

        public void UpdateGold(CharacterInventoryController inventory)
        {
            gold.text = inventory.Gold.ToString();
        }
    }
}