using System;
using UnityEngine;

namespace Item
{
    [Serializable]
    public class ItemData
    {
        [SerializeField]
        internal int Price;

        [SerializeField]
        internal Sprite Icon;

        [SerializeField]
        internal GameObject Prefab;
    }
}