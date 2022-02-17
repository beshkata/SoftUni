using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class UsersController : Controller
    {
        private IUserService userService;
        public UsersController(Request request, IUserService _userService)
            : base(request)
        {
            userService = _userService;
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterUserViewModel model)
        {
            var (isValid, errorMessage) = userService.ValidateModel(model);
        }
    }
}
