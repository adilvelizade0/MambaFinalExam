using Business.Services;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using X.PagedList;

namespace Mamba.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            var data = await _settingService.GetAll();
            return View(data.ToPagedList(page,2));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            try
            {
                var data = await _settingService.Get(id);
                return View(data);
            }
            catch (System.Exception e)
            {

                return RedirectToAction("Index", "Notfound");
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Setting setting)
        {
            if (!ModelState.IsValid)
            {
                return View(setting);
            }

            try
            {
                var data = await _settingService.Get(setting.Id);
                setting.Key = data.Key;
                await _settingService.Update(setting);

            }
            catch (System.Exception e)
            {

                return RedirectToAction("Index", "Notfound");
            }


            return RedirectToAction("Index");
        }
    }
}
