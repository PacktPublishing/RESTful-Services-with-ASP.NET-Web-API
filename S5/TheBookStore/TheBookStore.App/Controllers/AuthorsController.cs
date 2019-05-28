using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TheBookStore.App.Models;
using TheBookStore.Client;

namespace TheBookStore.App.Controllers
{
    public class AuthorsController : Controller
    {

        TheBookStoreClient client = new TheBookStoreClient();
        //
        // GET: /Authors/

        public ActionResult Details(int id)
        {
            var author = client.GetAuthor(id);
            return View(author);
        }

        public ActionResult Index()
        {
            var author = client.GetAuthors();
            return View(author);
        }

    }
}
