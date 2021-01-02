using AspNetCoreDiByName.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDiByName.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DtoA dto)
        {
            return RedirectToAction("Index");
        }
    }
}
