using DomainModel.DTO;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index(string accessMessageError)
        {
            return View(null, accessMessageError);
        }

        public IActionResult Location()
        {
            return View();
        }
    }
}