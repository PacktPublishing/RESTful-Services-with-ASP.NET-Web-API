using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBookStore.DataTransferObjects
{
    public class BookDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("isbn")]
        public string ISBN { get; set; }

        [JsonProperty("authors")]
        public IEnumerable<BookAuthorsDto> Authors { get; set; }

        [JsonProperty("reviews")]
        public IEnumerable<ReviewDto> Reviews { get; set; }

        [JsonProperty("averageRating")]
        public double AverageRating { get; set; }
    }
}