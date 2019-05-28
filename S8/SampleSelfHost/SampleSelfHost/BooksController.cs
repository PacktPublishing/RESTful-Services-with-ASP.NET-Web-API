using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;


namespace TheBookStore.Controllers
{
    public class BookDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

       
    }
    public class BooksController : ApiController
    {

        public IHttpActionResult Get()
        {
            var books = new BookDto[]{
                new BookDto{Id = 1, Title = "Test Book 1" },
                new BookDto{Id = 2, Title = "Test Book 2" },
                new BookDto{Id = 3, Title = "Test Book 3" },
                new BookDto{Id = 4, Title = "Test Book 4" }
            };

           
            return Ok(books);
        }

        

    }
}
