using EquipmentManager.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentManagerApi.Controllers
{
    [ApiController]
    [Route("api/v1/login")]
    public class LoginController : Controller
    {
        public async Task<ActionResult<dynamic>> AuthenticateAsync(User request)
        {
            return View();
        }
    }
}
