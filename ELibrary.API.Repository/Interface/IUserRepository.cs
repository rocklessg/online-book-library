using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public interface IUserRepository
    {
        Task<User> AddUser(RegistrationRequestDTO registrationRequestDTO);
        Task<bool> DeleteUser(string userId);
        IEnumerable<User> GetAllUsers();
        Task<User> GetUserByEmail(string userEmail);
        Task<bool> UpdateUserAvatarUrl(IFormFile image, string Id);
        Task<bool> UpdateUser(RegistrationRequestDTO updateUser, string id);
    }
}