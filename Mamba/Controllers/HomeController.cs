using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace Mamba.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;

        public HomeController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
