using Core;
using UnityEngine;

namespace Entity.Inventory
{
    public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
    {
        protected override bool IsDontDestroyOnLoad()
        {
            return false;
        }
        
        [Header("Tools")] public ItemData[] tools = new ItemData[8];
        public ItemData equippedTool;

        [Header("Items")] public ItemData[] items = new ItemData[8];
        public ItemData equippedItem;

        private void Start()
        {
        }

        private void Update()
        {
        }

    }
}