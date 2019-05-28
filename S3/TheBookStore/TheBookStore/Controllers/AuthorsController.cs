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
    public class AuthorsController : ApiController
    {
         IUnitOfWork unit;

         public AuthorsController()
        {
            this.unit = new SampleDataStore();

        }
        public IHttpActionResult Get()
        {

            var result = unit.Authors.All;

            if (!result.Any())
            {
                return NotFound();
            }

            var response = result.To<AuthorDto>();

            return Ok(response);
        }

    }
}
