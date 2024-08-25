using AYellowpaper.SerializedCollections;
using System;

namespace Resource
{
    [Serializable]
    class ResourceWallet
    {
        SerializedDictionary<string, int> _wallet;

        public void Configure(SerializedDictionary<string, int> wallet)
        {
            _wallet = wallet ?? new();
        }

        public int GetAmount(string id)
        {
            if (!_wallet.TryGetValue(id, out var amount))
                return 0;
            return amount;
        }

        public void Add(string id, int amount)
        {
            if (!_wallet.TryAdd(id, amount))
                _wallet[id] += amount;
        }

        public void Remove(string id, int amount)
        {
            _wallet[id] -= amount;
        }
    }
}
