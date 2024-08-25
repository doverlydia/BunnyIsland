using MVC;
using Savable;
using Zenject;

namespace Resource
{
    public class ResourcesController : Controller<ResourcesModel>
    {
        [Inject]
        SaveService _saveService;

        private void Awake()
        {
            var model = _saveService.Load<ResourcesModel>();
            SetModel(model);
        }
    }
}
