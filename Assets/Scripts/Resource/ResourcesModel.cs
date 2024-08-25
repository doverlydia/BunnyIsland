using AYellowpaper.SerializedCollections;
using MVC;
using System;

namespace Resource
{
    [Serializable]
    class ResourcesModel : Model
    {
        SerializedDictionary<string, int> _resources;

        internal void Configure(SerializedDictionary<string, int> resources)
        {
            _resources = resources ?? new();
        }

        internal int GetAmount(string id)
        {
            if (!_resources.TryGetValue(id, out var amount))
                return 0;
            return amount;
        }

        internal void Add(string id, int amount)
        {
            if (!_resources.TryAdd(id, amount))
                _resources[id] += amount;

            Changed();
        }

        internal void Remove(string id, int amount)
        {
            _resources[id] -= amount;

            Changed();
        }
    }
}
