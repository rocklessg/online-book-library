using ELibrary.API.Data;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System.Linq;

namespace ELibrary.API.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ElibraryDbContext _context;

        public ReviewRepository(ElibraryDbContext context)
        {
            _context = context;
        }

        public Review GetReviewById(string reviewId)
        {
            return _context.Reviews.FirstOrDefault(review => review.Id == reviewId);
        }


        public bool AddReview(AddReviewDTO addReview)
        {
            Review review = new()
            {
                BookId = addReview.BookId,
                Comment = addReview.Comment
            };

            // Saves the new review to the data store
            _context.Reviews.Add(review);
            _context.SaveChanges();
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }


        public bool UpdateReview(string reviewId, string comment)
        {
            //Gets the review to be updated by id and assign the new comment to the review comment field
            Review review = GetReviewById(reviewId);
            review.Comment = comment;

            // Saves the updated review comment to the data store
            _context.Reviews.Update(review);
            _context.SaveChanges();
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }
    }
}
