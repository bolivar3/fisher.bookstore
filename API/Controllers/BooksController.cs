using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fisher.Bookstore.Models;
using Microsoft.AspNetCore;

namespace Fisher.Bookstore.Api.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BookstoreController BookstoreContext db;

        public BooksController(BookstoreContext db)
        {
            this.db = db;
            if (this.db.Books.Count() == 0)
            {
                this.db.Books.Add(new Book()
                {
                  Id = 1,
                  Title = "Design Patterns",
                  Author = "Erich Gamma",
                  ISBN = "978-020163361"  
                });
                this.db.Books.Add(new Book()
                {
                  Id = 2,
                  Title = "Continuous Delivery",
                  Author = "Jez Humble",
                  ISBN = "978-0321601919"  
                });
                this.db.Books.Add(new Book()
                {
                  Id = 3,
                  Title = "The DevOps Handbook",
                  Author = "Gene Kim",
                  ISBN = "978-1942788003"  
                });
            }
            this.db.SaveChanges();

            [HttpGet]
            public IActionResult Get()
            {
                return Ok(db.Books);
            }
        }

    }
}
