using EasyButtons;
using Item;
using System.Linq;
using UnityEngine;
using UnityEngine.Splines;

namespace Shop
{
    class ShopViewController :  MonoBehaviour
    {
        [SerializeField]
        SplineContainer _splineContainer;
        [SerializeField]
        ShopModel _shopModel;
        [SerializeField]
        ItemDb _itemDb;

        [Button]
        internal void Configure()
        {
            var items = _shopModel.Shop.Select(x=> _itemDb.ItemMap[x.Key].Prefab).ToArray();
            foreach (var item in items)
            {
                var obj = Instantiate(item, _splineContainer.transform);
            }
        }
    }
}
