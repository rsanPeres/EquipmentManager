using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    public class EquipmentModelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
