using Business.Services;
using Common;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace Mamba.Areas.Admin.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IWebHostEnvironment _env;

        public MemberController(IMemberService memberService,IWebHostEnvironment env)
        {
            _memberService = memberService;
            _env = env;
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
                DeleteImage(_env.WebRootPath + "/uploads/members/" + data.ImageUrl);
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
                member.ImageUrl = await member.ImageFile.CreateImage(_env.WebRootPath,"members");
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
                var data = await _memberService.Get(member.Id);
                DeleteImage(_env.WebRootPath + "/uploads/members/"+ data.ImageUrl);
                member.ImageUrl = await member.ImageFile.CreateImage(_env.WebRootPath, "members");
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

        private void DeleteImage(string path)
        {
            System.IO.File.Delete(path);
        }
    }
}
