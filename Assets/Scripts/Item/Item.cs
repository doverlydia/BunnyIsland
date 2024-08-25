using System;
using UnityEngine;

namespace Item
{
    [Serializable]
    public class Item
    {
        [SerializeField]
        internal int Price;

        [SerializeField]
        internal Sprite Icon;

        [SerializeField]
        internal GameObject Prefab;
    }
}