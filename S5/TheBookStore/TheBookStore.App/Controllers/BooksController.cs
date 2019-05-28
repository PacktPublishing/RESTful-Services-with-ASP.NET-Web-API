using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheBookStore.App.Models;
using TheBookStore.Client;

namespace TheBookStore.App.Controllers
{
    public class BooksController : Controller
    {
        //
        // GET: /Books/
        TheBookStoreClient client = new TheBookStoreClient();

        public ActionResult Index()
        {
            var books = client.GetBooks();
            return View(books);
        }

        public ActionResult Details(int id)
        {
            var book = client.GetBook(id);
            return View(book);
        }
        [HttpPost]
        public ActionResult SubmitReview(ReviewModel review)
        {
            client.PostReview(review);
            return RedirectToAction("Details", new { id = review.bookid });
        }
    }
}
