using CarShop.Common;
using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;
        public UserService(
             IRepository _repo,
             IValidationService _validationService
             )
        {
            repo = _repo;
            validationService = _validationService;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
               .Where(u => u.Username == model.Username)
               .Where(u => u.Password == CalculateHash(model.Password))
               .SingleOrDefault();

            return user?.Id;
        }

        public (bool registered, string error) Register(RegisterViewModel model)
        {
            bool registered = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }
            if (UsernameExist(model.Username))
            {
                registered = false;
                error = ErrorMessages.UsernameExistErrorMessage;
                return (registered, error);
            }
            User user = new User()
            {
                Email = model.Email,
                Password = CalculateHash(model.Password),
                Username = model.Username,
                IsMechanic = model.UserType == "Mechanic" ? true : false,
            };

            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
                error = ErrorMessages.UnexpectedErrorErrorMessage;
            }

            return (registered, error);
        }

        private bool UsernameExist(string username)
        {
            return repo.All<User>()
                .Any(u => u.Username == username);
        }

        private string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }

        public bool IsUserMechanic(string userId)
        {
            User user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);

            return user.IsMechanic;
        }
    }
}
