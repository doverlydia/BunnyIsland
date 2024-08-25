using AYellowpaper.SerializedCollections;
using System;

namespace Inventory
{
    [Serializable]
    class InventoryData
    {
        SerializedDictionary<string, int> _inventory;
        
        internal void Configure(SerializedDictionary<string, int> inventory)
        {
            _inventory = inventory ?? new();
        }

        public int GetAmount(string id)
        {
            if (!_inventory.TryGetValue(id, out var amount))
                return 0;
            return amount;
        }

        public void Add(string id, int amount)
        {
            if (!_inventory.TryAdd(id, amount))
                _inventory[id] += amount;
        }

        public void Remove(string id, int amount)
        {
            _inventory[id] -= amount;
        }
    }
}
