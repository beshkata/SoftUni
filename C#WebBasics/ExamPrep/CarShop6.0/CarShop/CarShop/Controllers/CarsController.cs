using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using CarShop.Contracts;
using CarShop.ViewModels;

namespace CarShop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService carService;
        private readonly IUserService userService;
        public CarsController(
            Request request,
            ICarService _carService,
            IUserService _userService)
            : base(request)
        {
            carService = _carService;
            userService = _userService;
        }
        [Authorize]
        public Response All()
        {
            IEnumerable<AllCarsViewModel> cars = carService.GetAllCars(User.Id);

            return this.View(new
            { 
                cars = cars,
                IsAuthenticated = true
            });
        }

        [Authorize]
        public Response Add()
        {
            if (userService.IsUserMechanic(User.Id))
            {
                return Redirect("/Cars/All");
            }
            return View();
        }

        [HttpPost]
        [Authorize]
        public Response Add(AddCarViewModel model)
        {
            if (userService.IsUserMechanic(User.Id))
            {
                return Redirect("/Cars/All");
            }

            var (isAdded, error) = carService.AddCar(model, User.Id);

            if (isAdded)
            {
                return Redirect("/Cars/All");
            }

            return View(new { ErrorMessage = error }, "/Error");

        }
    }
}
