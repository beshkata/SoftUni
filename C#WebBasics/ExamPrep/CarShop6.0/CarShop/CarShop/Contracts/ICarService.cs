using CarShop.ViewModels;

namespace CarShop.Contracts
{
    public interface ICarService
    {
        (bool carAdded, string error) AddCar(AddCarViewModel model, string ownerId);
        IEnumerable<AllCarsViewModel> GetAllCars(string id);
    }
}
