using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TheBookStore.Contracts;
using TheBookStore.DataStores;
using TheBookStore.DataTransferObjects;
using TheBookStore.Models;

namespace TheBookStore.Controllers
{
  
    public class ReviewsController : ApiController
    {
        IUnitOfWork unit;

        public ReviewsController()
        {
            this.unit = new SampleDataStore();

        }

        public IHttpActionResult Get(int bookid)
        {
            var result = unit.Reviews.All(bookid);

            if (!result.Any())
            {
                return NotFound();
            }

            var response = result.To<ReviewDto>();

            return Ok(response);
        }

        public IHttpActionResult Post([FromBody]Review review, int bookid)
        {
            review.BookId = bookid;
            var newReview = unit.Reviews.AddReview(review);
            unit.Commit();

            var url = Url.Link("DefaultApi", new { controller = "Reviews", id = newReview.Id });

            return Created(url, newReview);
        }

        public IHttpActionResult Delete(int id)
        {
            unit.Reviews.RemoveReview(id);
            unit.Commit();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
