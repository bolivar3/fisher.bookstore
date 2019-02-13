using System;
using Microsoft.AspNetCore.Mvc;
using Fisher.Bookstore.Models;


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
            // we would normally get this from a database
            var featuredAuthor = new Author()
            {
                AuthorId = 1,
                Name = "J.K. Rowling" //or pick your favorite
            };
            return View(featuredAuthor);

        }
    }
}