using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(
            Request request,
            IUserService _userService)
            : base(request)
        {
            userService = _userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();
            string id = userService.Login(model);

            if (id == null)
            {
                return View();
            }

            SignIn(id);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return Redirect("/Players/All");
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View(new { IsAuthenticated = false });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            bool isRegistered = userService.Register(model);

            if (isRegistered)
            {
                return Redirect("/Users/Login");
            }

            return View();
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
