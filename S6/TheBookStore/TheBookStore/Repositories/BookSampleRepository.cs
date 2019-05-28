using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{
    public class BookSampleRepository : IBookRepository
    {
        List<Book> books;
        public BookSampleRepository()
        {
            var authors = new List<Author>
            {
                new Author{ Id = 1, Name = "Stefan", Surname = "Jonck"},
                new Author{ Id = 2, Name = "Claudio", Surname = "Vizzini"},
                new Author{ Id = 3, Name = "Jaco", Surname = "Visser"},
            };


            
            books = new List<Book>{
                new Book {  Id = 1,Title="Wedding Bells",Authors = new List<Author>{authors[0]}},
                new Book { Id = 2,Title="The truth about cricket", Authors = new List<Author>{authors[0], authors[2]}},
                new Book { Id = 3,Title="The fine art of Italian cooking",Authors = new List<Author>{authors[1]}},
                new Book { Id = 4,Title="Another day in Europe", Authors = new List<Author>{authors[1]}},
                new Book { Id = 5,Title="SQL for beginners", Authors = new List<Author>{authors[2]}},
            };

            
        }
        public IQueryable<Book> All
        {
            get { return books.AsQueryable(); }
        }

        public IQueryable<Book> Search(string criteria)
        {
            return books.Where(b => b.Title.ToLower().Contains(criteria.ToLower()) ||
                                            (b.Description != null && b.Description.Contains(criteria)) ||
                                            (b.ISBN != null && b.ISBN.Contains(criteria))).AsQueryable();
        }

        public Book GetOne(int Id)
        {
            return books.SingleOrDefault(b => b.Id == Id);
        }

        public Book Add(Book book)
        {
            books.Add(book);
            return books[books.Count];
        }

       
       
    }
}