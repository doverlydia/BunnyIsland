using Zenject;

namespace Savable
{
    public class SaveServiceInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SaveService>().AsSingle();
        }
    }
}
