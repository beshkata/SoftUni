using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
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

        public bool Register(RegisterViewModel model)
        {
            bool registered = false;

            bool isValid = validationService.ValidateModel(model);

            if (!isValid)
            {
                return isValid;
            }
            if (UsernameExist(model.Username))
            {
                registered = false;
                return registered;
            }
            User user = new User()
            {
                Email = model.Email,
                Password = CalculateHash(model.Password),
                Username = model.Username,
            };
            try
            {
                repo.Add(user);
                repo.SaveChanges();
                registered = true;
            }
            catch (Exception)
            {
            }

            return registered;
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
    }
}
