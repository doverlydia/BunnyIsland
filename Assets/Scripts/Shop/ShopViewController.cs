using EasyButtons;
using Item;
using UnityEngine;
using UnityEngine.Splines;

namespace Shop
{
    class ShopViewController : MonoBehaviour
    {
        [SerializeField]
        SplineContainer _splineContainer;
        [SerializeField]
        ShopModel _shopModel;
        [SerializeField]
        ItemDb _itemDb;

        [Button]
        internal void Configure(ItemData[] items)
        {
            foreach (var item in items)
            {
                Instantiate(item.Prefab, _splineContainer.transform);
            }
        }
    }
}
