using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "ItemDb", menuName = "Items/ItemDb")]
    public class ItemDb : ScriptableObject
    {
        public SerializedDictionary<string, ItemData> ItemMap;

        internal ItemData GetItem(string id)
        {
            if (ItemMap.TryGetValue(id, out var item))
                return item;
            return null;
        }
    }
}