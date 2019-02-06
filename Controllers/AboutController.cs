using System;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    [Route("About")]
    public class AboutController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("History")]
        public IActionResult History()
        {
            return View();
        }
        [Route("Location")]
        public IActionResult Location()
        {
            return View();
        }
    }
}