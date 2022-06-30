using Business.Services;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace Mamba.Areas.Admin.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _memberService.GetAll();
            return View(data.ToPagedList(page, 2));
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var data = await _memberService.Get(id);
                await _memberService.Delete(data);
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


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Member member)
        {
            if (!ModelState.IsValid)
            {
                return View(member);
            }

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

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            try
            {
                var data = await _memberService.Get(id);
                return View(data);
            }
            catch (System.Exception e)
            {

                return Json(new
                {
                    error = e.Message
                });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var data = await _memberService.Get(id);
                return View(data);
            }
            catch (System.Exception e)
            {

                return Json(new
                {
                    error = e.Message
                });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Member member)
        {
            try
            {
                await _memberService.Update(member);

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
