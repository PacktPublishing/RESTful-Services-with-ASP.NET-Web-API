using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBookStore.Client
{
    public class ReviewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int rating { get; set; }
        public string feedback { get; set; }
        public int bookid { get; set; }
    }
}