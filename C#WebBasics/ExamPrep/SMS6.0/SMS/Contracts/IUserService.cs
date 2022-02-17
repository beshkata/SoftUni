using SMS.Models.UserViewModels;
using System;

namespace SMS.Contracts
{
    public interface IUserService
    {
        public (bool isValid, string errorMessage) ValidateModel(RegisterUserViewModel model);
    }
}
