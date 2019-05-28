using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TheBookStore.Contracts;
using TheBookStore.Models;

namespace TheBookStore.Repositories
{
    public class ReviewSampleRepository : IReviewRepository
    {
        List<Review> reviews;

        public ReviewSampleRepository()
        {
            var books = new List<Book>{
                new Book { Id = 1,Title="Wedding Bells"},
                new Book { Id = 2,Title="The truth about cricket"},
                new Book { Id = 3,Title="The fine art of Italian cooking"},
                new Book { Id = 4,Title="Another day in Europe"},
                new Book { Id = 5,Title="SQL for beginners"},
            };

            reviews = new List<Review>
            {
                new Review{Id = 1,Name = "Brian Baker",Rating = 4,Feedback="Excellent book!", Book = books[0]},
                new Review{Id = 2,Name = "Shane Roode",Rating = 3,Feedback="Now I want to travel. Thanks!", Book = books[3]},
                new Review{Id = 3,Name = "Steve Phillips",Rating = 3,Feedback="Moving story...", Book = books[0]},
                new Review{Id = 4,Name = "Fanie Reynders",Rating = 4,Feedback="This is so easy to learn.", Book = books[4]},
            };
        }


        public IQueryable<Review> All(int bookId)
        {
            return reviews.Where(r => r.Book.Id == bookId).AsQueryable();
        }

        public Review AddReview(Review review)
        {
            review.Id = reviews.Count;
            reviews.Add(review);

            return reviews[reviews.Count-1];
        }

        public Review RemoveReview(int Id)
        {
            var review = reviews.SingleOrDefault(r=>r.Id == Id);
            if (review != null)
            {
                reviews.Remove(review);
                return review;
            }
            return null;
        }
    }
}