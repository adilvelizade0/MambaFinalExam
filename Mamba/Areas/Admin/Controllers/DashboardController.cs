using Microsoft.AspNetCore.Mvc;

namespace Mamba.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
