using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBookStore.DataTransferObjects
{
    public class ReviewDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("rating")]
        public int Rating { get; set; }

        [JsonProperty("feedback")]
        public string Feedback { get; set; }

        [JsonProperty("bookId")]
        public int BookId { get; set; }
    }
}