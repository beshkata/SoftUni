using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;
        private readonly IUserService userService;
        public IssuesController(
            Request request,
            IIssueService _issueService,
            IUserService _userService)
            : base(request)
        {
            issueService = _issueService;
            userService = _userService;
        }

        public Response CarIssues(string carId)
        {
            IEnumerable<CarIssueViewModel> issues = issueService.GetAllIssues(carId);

            return this.View(new
            {
                issues = issues,
                IsAuthenticated = true
            });
        }

        [Authorize]
        public Response Add()
        {
            return View(new  { IsAuthenticated = true });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddIssueViewModel model)
        {
            var (isAdded, error) = issueService.AddIssue(model);

            if (isAdded)
            {
                return Redirect("/Issues/CarIssues");
            }

            return View(new { ErrorMessage = error }, "/Error");

        }
    }
}
