using UnityEngine;

namespace Application.Entity.Inventory
{
    [CreateAssetMenu(menuName = "Items/Equipment")]
    public class EquipmentData : ItemData
    {
        public enum ToolType
        {
            Hoe,
            WateringCan,
            Axe,
            Pickaxe
        }

        public ToolType toolType;
    }
}