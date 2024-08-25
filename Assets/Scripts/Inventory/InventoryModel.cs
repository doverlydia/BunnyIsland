using AYellowpaper.SerializedCollections;
using MVC;
using System;

namespace Inventory
{
    [Serializable]
    class InventoryModel : Model
    {
        SerializedDictionary<string, int> _inventory;

        internal void Configure(SerializedDictionary<string, int> inventory)
        {
            _inventory = inventory ?? new();
            Changed();
        }

        internal int GetAmount(string id)
        {
            if (!_inventory.TryGetValue(id, out var amount))
                return 0;
            return amount;
        }

        internal void Add(string id, int amount)
        {
            if (!_inventory.TryAdd(id, amount))
                _inventory[id] += amount;
            
            Changed();
        }

        internal void Remove(string id, int amount)
        {
            _inventory[id] -= amount;

            Changed();
        }
    }
}
