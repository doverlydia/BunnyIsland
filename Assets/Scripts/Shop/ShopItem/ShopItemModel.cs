using MVC;
using UnityEngine;

namespace Shop
{
    class ShopItemModel : Model
    {
        internal int Price;
        internal GameObject Prefab;

        public ShopItemModel(int price, GameObject prefab)
        {
            Price = price;
            Prefab = prefab;
        }
    }
}
