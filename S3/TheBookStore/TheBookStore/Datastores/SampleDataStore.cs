using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;
using TheBookStore.Repositories;

namespace TheBookStore.DataStores
{
    public class SampleDataStore:IUnitOfWork
    {
        
        private IBookRepository books;
        private IAuthorRepository authors;
        private IReviewRepository reviews;

        public void Commit()
        {
            
        }

        public IBookRepository Books
        {
            get
            {
                if (books == null)
                {
                    books = new BookSampleRepository();
                }

                return books;
            }
        }

        public IAuthorRepository Authors
        {
            get
            {
                if (authors == null)
                {
                    authors = new AuthorSampleRepository();
                }

                return authors;
            }
        }

        public IReviewRepository Reviews
        {
            get
            {
                if (reviews == null)
                {
                    reviews = new ReviewSampleRepository();
                }

                return reviews;
            }
        }
    }
}