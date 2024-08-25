using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Resource.Icon
{
    class ResourceIconView : MonoBehaviour
    {
        [Inject]
        ResourceIconDb _db;

        [SerializeField]
        Image _iconImage;

        internal void Configure(string id)
        {
            var icon = _db.GetResourceIcon(id);
            if(icon!=null)
                _iconImage.sprite = icon;
        }
    }
}
