﻿using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace BasicWebServer.Demo.Controllers
{
    public class UserController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
   Username: <input type='text' name='Username'/>
   Password: <input type='text' name='Password'/>
   <input type='submit' value ='Log In' /> 
</form>";
        private const string Username = "user";
        private const string Password = "user123";

        public UserController(Request request)
            : base(request)
        {
        }

        public Response Login() => View();//Html(LoginForm);

        public Response LogInUser()
        {
            Request.Session.Clear();

            var usernameMatches = Request.Form["Username"] == Username;
            var passwordMatches = Request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                if (!Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName,
                        Request.Session.Id);

                    return Html("<h3>Logged successfully</h3>", cookies);
                }
                return Html("<h3>Logged successfully</h3>");
            }
            return Redirect("/Login");
        }

        public Response GetUserData()
        {
            if (Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logget-in user " + $"is with username '{Username}'</h3>");
            }
            else
            {
                return Html("<h3>You should first log in " + "- <a href='/Login'>Login</a></h3>");
            }

        }

        public Response Logout()
        {
            Request.Session.Clear();

            return Html("<h3>Logged out successfully<h3>");
        }
    }
}
