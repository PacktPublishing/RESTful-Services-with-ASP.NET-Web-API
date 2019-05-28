using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using TheBookStore.Models;

namespace TheBookStore.Infrastructure
{
    public class CheckNull : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            

            if (actionExecutedContext.Response.StatusCode == HttpStatusCode.NotFound)
                actionExecutedContext.Response = 
                    actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.NotFound, 
                    "No results found for the given query");

            base.OnActionExecuted(actionExecutedContext);

        }
    }
}