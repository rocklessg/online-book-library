using ELibrary.API.Model.DTO.RequestDTO;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public interface IReviewRepository
    {
        bool AddReview(AddReviewDTO addReview);
        bool UpdateReview(string reviewId, string comment);
        Task<bool> DeleteUser(string id);
    }
}