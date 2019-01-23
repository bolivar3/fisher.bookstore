using System;
using Microsoft.AspNetCore.Mvc;

namespace Fisher.Bookstore.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            return Content("This is the Index");
        }
        public IActionResult New()
        {
            return Content("These are the new books");
        }
        public IActionResult Best() //best-sellers did not work so I left it at best()
        {
            return Content("These are the best-seller books");
        }
    }
}