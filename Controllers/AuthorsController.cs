using System;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    [Route("Authors")]
    public class AuthorsController : Controller
    {
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("Featured")]
        public IActionResult Featured()
        {
            return View();
        }
    }
}