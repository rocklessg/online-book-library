using ELibrary.API.Model;

namespace ELibrary.API.Repository
{
    public interface IRatingRepository
    {
        Rating GetRatingById(string ratingId);
        bool AddRating(Rating rating);
        bool UpdateRating(string ratingId);
    }
}