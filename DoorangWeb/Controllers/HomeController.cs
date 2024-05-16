
using Bussiness.Abstracts;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DoorangWeb.Controllers
{
    public class HomeController : Controller
    {
        IExploreService _exploreService { get; set; }

        public HomeController(IExploreService exploreService)
        {
            _exploreService = exploreService;
        }

        public IActionResult Index()
        { List<Explore> explore = _exploreService.GetAllExplore();
            return View(explore);
        }

        
    }
}
