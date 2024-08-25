using AYellowpaper.SerializedCollections;
using MVC;
using Savable;
using System;
using Unity.Plastic.Newtonsoft.Json;

namespace Inventory
{
    [Serializable]
    public class InventoryModel : Model, ISavable
    {
        SerializedDictionary<string, int> _inventory;

        [JsonConstructor]
        public InventoryModel(SerializedDictionary<string, int> inventory)
        {
            _inventory = inventory;
        }

        public InventoryModel()
        {
            _inventory = new();
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
