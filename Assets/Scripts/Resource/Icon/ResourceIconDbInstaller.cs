using Zenject;
using UnityEngine;

namespace Resource.Icon
{
    class ResourceIconDbInstaller : MonoInstaller
    {
        [SerializeField]
        ResourceIconDb _iconDb;

        public override void InstallBindings()
        {
            Container.Bind<ResourceIconDb>().FromInstance(_iconDb).AsSingle();
            Container.Bind<ResourcesModel>().AsSingle();
        }
    }
}
