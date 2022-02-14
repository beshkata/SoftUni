using SharedTrip.Models;
using SharedTrip.Models.TripViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(AddTripViewModel model);
        Task AddTripAsync(AddTripViewModel model);
        IEnumerable<AllTripViewModel> GetAllTrips();
        TripDetailsViewModel GetTripDetails(string tripId);
        void AddUserToTrip(string tripId, string id);
    }
}
