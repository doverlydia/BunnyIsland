using AYellowpaper.SerializedCollections;
using MVC;
using Savable;
using System;
using Unity.Plastic.Newtonsoft.Json;

namespace Resource
{
    [Serializable]
    public class ResourcesModel : Model, ISavable
    {
        SerializedDictionary<string, int> _resources;

        [JsonConstructor]
        public ResourcesModel(SerializedDictionary<string, int> resources)
        {
            _resources = resources;
        }

        public ResourcesModel()
        {
            _resources = new();
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
