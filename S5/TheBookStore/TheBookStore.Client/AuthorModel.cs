using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBookStore.Client
{
    public class AuthorModel
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public IEnumerable<BookItem> Books { get; set; }
    }
}