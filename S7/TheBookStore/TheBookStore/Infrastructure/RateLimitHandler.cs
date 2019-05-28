using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TheBookStore.Models;

namespace TheBookStore.Infrastructure
{
    public class RateLimitHandler : DelegatingHandler
    {
        const int timeout = 20;
        const int limit = 5;
        const string basicAuthResponseHeader = "WWW-Authenticate";
        const string basicAuthResponseHeaderValue = "Basic";

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            if (request.Headers.Authorization == null)
            {
                var noAuthResponse = request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization token required!");
                noAuthResponse.Headers.Add(basicAuthResponseHeader, basicAuthResponseHeaderValue);

                return noAuthResponse;
            }

            var token = request.Headers.Authorization.Parameter;
            var query = request.RequestUri.PathAndQuery;
            var throttleKey = string.Format("{0}:{1}", query, token);
            var hit = HttpRuntime.Cache.Get(throttleKey) as RateLimit;

            HttpResponseMessage response;

            if (hit == null)
                hit = new RateLimit(throttleKey, limit, timeout);

            if (!hit.CheckLimit())
            {
                var message = String.Format("Rate-limit of {0} reached! Try again in {1} second(s)", hit.Limit, hit.RemainingSeconds);
                response = request.CreateErrorResponse((HttpStatusCode)429, message);

                response.ReasonPhrase = message;

            }
            else
            {
                response = await base.SendAsync(request, cancellationToken);
            }

            response.Headers.Add("X-Rate-Limit-Limit", hit.Limit.ToString());
            response.Headers.Add("X-Rate-Limit-Remaining", hit.RemainingHits.ToString());
            response.Headers.Add("X-Rate-Limit-Reset", hit.Reset.ToUniversalTime().ToString());

            return response;
        }
    }
}