using Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace Mamba.Areas.Admin.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<IActionResult> Index(int page)
        {
            var data = await _memberService.GetAll();
            return View(data.ToPagedList(page, 2));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
