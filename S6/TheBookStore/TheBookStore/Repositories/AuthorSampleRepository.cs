using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{
    public class AuthorSampleRepository:IAuthorRepository
    {

        List<Author> authors;

        public AuthorSampleRepository()
        {
            var bookList1 = new List<Book>{
                new Book { Id = 1,Title="Wedding Bells"},
                new Book { Id = 2,Title="The truth about cricket"},
            };
            var bookList2 = new List<Book>{
                new Book { Id = 3,Title="The fine art of Italian cooking"},
                new Book { Id = 4,Title="Another day in Europe"},
            };
            var bookList3 = new List<Book>{
                new Book { Id = 5,Title="SQL for beginners"},
                new Book { Id = 2,Title="The truth about cricket"},
            };

            authors = new List<Author>
            {
                new Author{ Id = 1, Name = "Stefan", Surname = "Jonck", Books = bookList1},
                new Author{ Id = 2, Name = "Claudio", Surname = "Vizzini", Books = bookList2},
                new Author{ Id = 3, Name = "Jaco", Surname = "Visser", Books = bookList3},
            };
        }

        public IQueryable<Author> All
        {
            get { return authors.AsQueryable(); }
        }
    }
}