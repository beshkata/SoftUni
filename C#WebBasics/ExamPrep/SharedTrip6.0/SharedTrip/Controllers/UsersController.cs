using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.UserViewModels;
using SharedTrip.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        public UsersController(Request request, IUserService userService)
            : base(request)
        {
            _userService = userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public Response Login(UserLoginViewModel model)
        {
            Request.Session.Clear();

            (string userId, bool isCorrect) = _userService.IsLoginCorrect(model);

            if (isCorrect)
            {
                SignIn(userId);

                CookieCollection cookies = new CookieCollection();
                cookies.Add(Session.SessionCookieName,
                    Request.Session.Id);

                return Redirect("/Trips/All");
            }

            return View(new List<ErrorViewModel>() { new ErrorViewModel("Login incorrect") }, "/Error");
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public Response Register(UserRegistrationViewModel model)
        {
            var (isValid, errors) = _userService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }
            try
            {
                _userService.RegisterUser(model);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected Error") }, "/Error");
            }

            return Redirect("/Users/Login");
        }

    }
}
