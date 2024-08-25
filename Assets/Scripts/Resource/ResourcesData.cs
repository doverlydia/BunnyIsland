using AYellowpaper.SerializedCollections;
using System;

namespace Resource
{
    [Serializable]
    class ResourcesData
    {
        SerializedDictionary<string, int> _resources;

        internal void Configure(SerializedDictionary<string, int> resources)
        {
            _resources = resources ?? new();
        }

        public int GetAmount(string id)
        {
            if (!_resources.TryGetValue(id, out var amount))
                return 0;
            return amount;
        }

        public void Add(string id, int amount)
        {
            if (!_resources.TryAdd(id, amount))
                _resources[id] += amount;
        }

        public void Remove(string id, int amount)
        {
            _resources[id] -= amount;
        }
    }
}
