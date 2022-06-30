using Microsoft.AspNetCore.Mvc;

namespace Mamba.Areas.Admin.Controllers
{
    public class NotfoundController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
