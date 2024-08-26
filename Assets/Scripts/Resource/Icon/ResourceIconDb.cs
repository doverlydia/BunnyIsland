using AYellowpaper.SerializedCollections;
using UnityEngine;
namespace Resource.Icon
{
    [CreateAssetMenu(fileName = "ResourceIconDb", menuName = "Resource")]
    class ResourceIconDb : ScriptableObject
    {
        [SerializedDictionary("Item Id", "Icon"), SerializeField]
        SerializedDictionary<string, Sprite> _resourceSpriteMap;

        internal Sprite GetResourceIcon(string id)
        {
            if (_resourceSpriteMap.TryGetValue(id, out var icon))
                return icon;
            return null;
        }
    }
}
