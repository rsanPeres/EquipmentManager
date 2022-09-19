using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
