using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Item
{
    [CreateAssetMenu(fileName = "ItemDb", menuName = "Items/ItemDb")]
    class ItemDb : ScriptableObject
    {
        [SerializeField]
        SerializedDictionary<string, Item> _itemMap;

        internal Item GetItem(string id)
        {
            if (_itemMap.TryGetValue(id, out var item))
                return item;
            return null;
        }
    }
}