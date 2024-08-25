using MVC;
using Savable;
using Zenject;

namespace Inventory
{
    public class InventoryController : Controller<InventoryModel>
    {
        [Inject]
        SaveService _saveService;

        private void Awake()
        {
            var model = _saveService.Load<InventoryModel>();
            SetModel(model);
        }
    }
}
