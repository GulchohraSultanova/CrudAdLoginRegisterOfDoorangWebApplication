using Bussiness.Abstracts;
using Bussiness.Exceptions;
using Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace DoorangWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ExploreController : Controller
    {
        IExploreService _exploreService;

        public ExploreController(IExploreService exploreService)
        {
            _exploreService = exploreService;
        }

        public IActionResult Index()
        {
            var explores=_exploreService.GetAllExplore();
            return View(explores);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Explore explore) {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _exploreService.Create(explore);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("",ex.Message);
            }
            catch (FileContentTypeException ex) 
            { 
                ModelState.AddModelError("PhotoFile",ex.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id) { 
            var explore=_exploreService.GetExplore(x=>x.Id == id);
            return View(explore);
        }
        [HttpPost]
        public IActionResult Update(Explore explore)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _exploreService.Update(explore);
            }
            catch (NotFoundException ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            catch (FileContentTypeException ex)
            {
                ModelState.AddModelError("PhotoFile", ex.Message);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
           
            _exploreService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
