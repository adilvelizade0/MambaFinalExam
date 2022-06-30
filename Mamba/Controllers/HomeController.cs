using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mamba.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMemberService _memberService;

        public HomeController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _memberService.GetAll();
            return View(data);
        }
    }
}
