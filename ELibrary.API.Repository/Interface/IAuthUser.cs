using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public interface IAuthUser
    {
        Task<User> Login(LoginRequestDTO userRequest);
        Task<User> Register(User user);
    }
}