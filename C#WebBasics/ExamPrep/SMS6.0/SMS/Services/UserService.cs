using SMS.Contracts;
using SMS.Models.UserViewModels;
using System.Text;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        public (bool isValid, string errorMessage) ValidateModel(RegisterUserViewModel model)
        {
            StringBuilder sb = new StringBuilder();

            bool isValid = true;



            return (isValid, sb.ToString());
        }
    }
}
