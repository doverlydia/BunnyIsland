using UnityEngine;
using Zenject;

namespace Item
{
    public class ItemDbInstaller : MonoInstaller
    {
        [SerializeField]
        ItemDb _itemDb;

        public override void InstallBindings()
        {
            Container.Bind<ItemDb>().FromInstance(_itemDb).AsSingle();
        }
    }
}
