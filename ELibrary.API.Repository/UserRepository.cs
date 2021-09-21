using AutoMapper;
using ELibrary.API.Model;
using ELibrary.API.Model.DTO.RequestDTO;
using ELibrary.API.Services.ImageUploadService.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ELibrary.API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly IUploadImage _uploadImage;
        private readonly IMapper _mapper;

        public UserRepository(UserManager<User> userManager, IMapper mapper, IUploadImage uploadImage)
        {
            _userManager = userManager;
            _uploadImage = uploadImage;
            _mapper = mapper;
        }

        public async Task<User> GetUserByUserName(string userName) => await _userManager.FindByNameAsync(userName);

        public async Task<User> GetUserByEmail(string userEmail) => await _userManager.FindByEmailAsync(userEmail);

        public async Task<User> AddUser(RegistrationRequestDTO registrationRequestDTO)
        {
            registrationRequestDTO.UserName = String.IsNullOrWhiteSpace(registrationRequestDTO.UserName) ? registrationRequestDTO.Email : registrationRequestDTO.UserName;

            User user = _mapper.Map<User>(registrationRequestDTO);

            IdentityResult result = await _userManager.CreateAsync(user, registrationRequestDTO.Password);
            if (result.Succeeded)
            {
                return user;
            }
            string errors = String.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }





        public IEnumerable<User> GetAllUsers()
        {
            return _userManager.Users;
        }


        public async Task<bool> DeleteUser(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return true;
                return false;
            }
            throw new ArgumentException("User does not exist");
        }


        public async Task<bool> UpdateUser(RegistrationRequestDTO updateUser, string id)
        {
            User user = await _userManager.FindByIdAsync(id);

            user.FirstName = String.IsNullOrWhiteSpace(updateUser.FirstName) ? user.FirstName : updateUser.FirstName;
            user.LastName = String.IsNullOrWhiteSpace(updateUser.LastName) ? user.LastName : updateUser.LastName;
            user.Email = String.IsNullOrWhiteSpace(updateUser.Email) ? user.Email : updateUser.Email;
            user.UserName = String.IsNullOrWhiteSpace(updateUser.UserName) ? user.UserName : updateUser.UserName;
            user.ImageUrl = String.IsNullOrWhiteSpace(updateUser.ImageUrl) ? user.ImageUrl : updateUser.ImageUrl;
            user.UpdatedAt = DateTime.Now;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return true;
            return false;

        }


        public async Task<bool> UpdateUserAvatarUrl(IFormFile image, string Id)
        {
            var upload = _uploadImage.ImageUploadAsync(image);
            string url = upload.Result.Url.ToString();

            User user = await _userManager.FindByIdAsync(Id);
            user.ImageUrl = url;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return true;
            return false;
        }
    }
}
