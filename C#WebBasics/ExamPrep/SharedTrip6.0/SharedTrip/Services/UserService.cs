using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository _repo;
        public UserService(IRepository repo)
        {
            _repo = repo;
        }
        public (bool isValid, IEnumerable<ErrorViewModel> errors) 
            ValidateModel(UserRegistrationViewModel model)
        {
            List<ErrorViewModel> errors = new List<ErrorViewModel>();
            bool isValid = true;

            if (model.Username == null ||
                 model.Username.Length < 5 ||
                 model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username is requred and must be between 5 and 20 characters"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required"));
            }

            if (model.Password == null ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password is requred and must be between 6 and 20 characters"));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password and ConfirmPasswor are not the same"));
            }

            return (isValid, errors);
        }

        public void RegisterUser(UserRegistrationViewModel model)
        {
            var userExists = GetUserByUsername(model.Username) != null;

            if (userExists)
            {
                throw new ArgumentException("Registration failed");
            }

            User user = new User()
            {
                Email = model.Email,
                Username = model.Username
            };

            user.Password = HashPassword(model.Password);

            _repo.Add(user);
            _repo.SaveChanges();
        }

        private User GetUserByUsername(string username)
        {
            return _repo.All<User>()
                .FirstOrDefault( u => u.Username == username);
        }

        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using(SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        public (string userId, bool isCorrect) IsLoginCorrect(UserLoginViewModel model)
        {
            bool isCorrect = false;
            string userId = String.Empty;

            var user = GetUserByUsername(model.Username);

            if (user != null)
            {
                isCorrect = user.Password == HashPassword(model.Password);
            }

            if (isCorrect)
            {
                userId = user.Id;
            }

            return (userId, isCorrect);
        }
    }

}
