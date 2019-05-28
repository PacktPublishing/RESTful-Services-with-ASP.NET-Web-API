using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using TheBookStore.Contracts;

namespace TheBookStore.Infrastructure
{
    public class CustomPrincipalProvider : IPrincipalProvider
    {
        private const string Username = "fanier";
        private const string Password = "supersecretpassword";

        public IPrincipal CreatePrincipal(string username, string password)
        {
            if (username != Username || password != Password)
            {
                return null;
            }

            var identity = new GenericIdentity(Username);
            IPrincipal principal = new GenericPrincipal(identity, new[] { "User" });
            return principal;
        }
    }
}