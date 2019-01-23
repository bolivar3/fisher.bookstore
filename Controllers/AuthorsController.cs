using System;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index()
        {
            return Content("This is the Index");
        }
        public IActionResult Featured()
        {
            return Content("These are the featured authors");
        }
    }
}