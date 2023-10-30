using UnityEngine;

namespace Entity.Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [Header("Tools")] public ItemData[] tools = new ItemData[8];
        public ItemData equippedTool;

        [Header("Items")] public ItemData[] items = new ItemData[8];
        public ItemData equippedItem;
        public static InventoryManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
                Destroy(this);
            else
                Instance = this;
        }

        private void Start()
        {
        }

        private void Update()
        {
        }
    }
}