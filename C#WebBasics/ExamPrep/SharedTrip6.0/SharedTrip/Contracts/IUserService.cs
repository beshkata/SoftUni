using SharedTrip.Models;
using SharedTrip.Models.UserViewModels;
using System.Collections.Generic;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(UserRegistrationViewModel model);
        void RegisterUser(UserRegistrationViewModel model);
        (string userId, bool isCorrect) IsLoginCorrect(UserLoginViewModel model);
    }
}
