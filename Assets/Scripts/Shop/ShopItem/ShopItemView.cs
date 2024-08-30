using MVC;
using UnityEngine;

namespace Shop
{
    class ShopItemView : View<ShopItemModel>
    {
        GameObject _obj;
        protected override void OnModelReplaced()
        {
            if (_obj != null)
                Destroy(_obj);
        }
    }
}
