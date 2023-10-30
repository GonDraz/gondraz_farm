using UnityEngine;

namespace Application.Entity.Inventory
{
    [CreateAssetMenu(menuName = "Items/Item")]
    public class ItemData : ScriptableObject
    {
        public string description;

        public Sprite thumbnail;

        public GameObject gameModel;
    }
}