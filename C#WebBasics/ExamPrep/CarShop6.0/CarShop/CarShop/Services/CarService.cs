using CarShop.Common;
using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;

namespace CarShop.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository repo;

        private readonly IValidationService validationService;
        public CarService(
             IRepository _repo,
             IValidationService _validationService
             )
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool carAdded, string error) AddCar(AddCarViewModel model, string ownerId)
        {
            bool carAdded = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Car car = new Car()
            {
                Model = model.Model,
                Year = model.Year,
                OwnerId = ownerId,
                PictureUrl = model.ImageUrl,
                PlateNumber = model.PlateNumber
            };
            try
            {
                repo.Add(car);
                repo.SaveChanges();
                carAdded = true;
            }
            catch (Exception)
            {
                error = ErrorMessages.UnexpectedErrorErrorMessage;
            }

            return (carAdded, error);

        }

        public IEnumerable<AllCarsViewModel> GetAllCars(string id)
        {
            var cars = repo.All<Car>()
                .Where(c => c.OwnerId == id)
                .Select(c => new AllCarsViewModel
                {
                    CarId = c.Id,
                    PictureUrl = c.PictureUrl,
                    PlateNumber = c.PlateNumber,
                    Model = c.Model,
                    FixedIssues = c.Issues.Where(i => i.IsFixed == true).Count(),
                    RemainingIssues = c.Issues.Where(i => i.IsFixed == false).Count()
                })
                .ToList();
            return cars;
        }
    }
}
