using Business.Services;
using DAL.Models;
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            try
            {
                await _memberService.Create(member);
            }
            catch (System.Exception e)
            {

                return Json(new
                {
                    error = e.Message
                });
            }
            return RedirectToAction("Index");
        }
    }
}
