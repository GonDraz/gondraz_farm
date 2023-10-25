using UnityEngine;

namespace Inventory
{
    [CreateAssetMenu(menuName = "Items/Item")]
    public class ItemData : ScriptableObject
    {
        public string description;

        public Sprite thumbnail;

        public GameObject gameModel;
    }
}