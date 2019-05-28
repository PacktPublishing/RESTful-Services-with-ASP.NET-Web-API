using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheBookStore.Contracts;
using TheBookStore.DataStores;
using TheBookStore.DataTransferObjects;

namespace TheBookStore.Controllers
{
    public class BooksController : ApiController
    {

        private IUnitOfWork unit;

        public BooksController()
        {
            this.unit = new SampleDataStore();
        }


        public IHttpActionResult Get()
        {
            var books = unit.Books.All;

            var response = books.To<BookDto>();

            return Ok(response);
        }

        public IHttpActionResult Get(string query)
        {
            var results = unit.Books.Search(query);

            if (!results.Any())
            {
                return NotFound();
            }

            var response = results.To<BookDto>();

            return Ok(response);

        }


        public IHttpActionResult Get(int id)
        {
            var result = unit.Books.GetOne(id);

            if (result == null)
            {
                return NotFound();
            }

            var response = result.To<BookDto>();

            return Ok(response);
        }




    }
}
