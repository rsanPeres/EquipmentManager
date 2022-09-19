using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
