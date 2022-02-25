using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface IUserService
    {
        (bool registered, string error) Register(RegisterViewModel model);

        string Login(LoginViewModel model);

        bool IsUserMechanic(string userId);

        //string GetUsername(string userId);
    }
}
