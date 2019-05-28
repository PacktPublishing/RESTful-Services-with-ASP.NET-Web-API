using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TheBookStore.DataTransferObjects
{
    public class AuthorDto
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("books")]
        public IEnumerable<AuthorBooksDto> Books { get; set; }
    }
}