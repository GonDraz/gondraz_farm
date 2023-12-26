using UnityEngine;

namespace Entity.Inventory
{
    [CreateAssetMenu(menuName = "GonDraz/Inventory/Items/Seed")]
    public class SeedData : ItemData
    {
        [InspectorName("Time it takes before the seed matures into a crop")]
        public int daysToGrow;

        [InspectorName("The crop the seed will yield")]
        public ItemData cropToYield;
    }
}