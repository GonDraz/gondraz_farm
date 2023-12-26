using UnityEngine;

namespace Entity.Inventory
{
    [CreateAssetMenu(menuName = "GonDraz/Inventory/Items/Item")]
    public class ItemData : ScriptableObject
    {
        public string description;

        public Sprite thumbnail;

        public GameObject gameModel;
    }
}