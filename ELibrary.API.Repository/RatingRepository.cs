using ELibrary.API.Data;
using ELibrary.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ELibrary.API.Repository
{
    public class RatingRepository : IRatingRepository
    {
        private readonly ElibraryDbContext _context;

        public RatingRepository(ElibraryDbContext context)
        {
            _context = context;
        }

        public Rating GetRatingById(string ratingId)
        {
            return _context.Ratings.FirstOrDefault(rating => rating.Id == ratingId);
        }


        public bool AddRating(Rating rating)
        {
            _context.Ratings.Add(rating);
            _context.SaveChanges();
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }


        public bool UpdateRating(string ratingId)
        {
            Rating rating = GetRatingById(ratingId);
            _context.Ratings.Add(rating);
            _context.SaveChanges();
            if (_context.SaveChanges() != 0)
                return true;
            return false;
        }
    }
}
