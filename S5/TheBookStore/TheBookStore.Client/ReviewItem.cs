using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheBookStore.Client
{
    public class ReviewItem
    {
        public int id { get; set; }
        public string reviewer { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
    }
}
