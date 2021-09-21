using ELibrary.API.Model.DTO.RequestDTO;

namespace ELibrary.API.Repository
{
    public interface IReviewRepository
    {
        bool AddReview(AddReviewDTO addReview);
        bool UpdateReview(string reviewId, string comment);
    }
}