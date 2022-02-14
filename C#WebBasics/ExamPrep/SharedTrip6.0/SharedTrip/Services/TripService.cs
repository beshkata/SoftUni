using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using SharedTrip.Models.TripViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository _repo;

        public TripService(IRepository repo)
        {
            _repo = repo;
        }
        public async Task AddTripAsync(AddTripViewModel model)
        {
            DateTime departureTime;
            DateTime.TryParseExact(model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out departureTime);

            Trip trip = new Trip
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                DepartureTime = departureTime,
                Description = model.Description
            };

            await _repo.AddAsync(trip);
            await _repo.SaveChangesAsync();
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(AddTripViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();
            DateTime date;

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                errors.Add(new ErrorViewModel("StartPoint is required!"));
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                errors.Add(new ErrorViewModel("EndPoint is required!"));
                isValid = false;
            }
            if (!DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, 
                out date))
            {
                errors.Add(new ErrorViewModel("DepartureTime is not in required format!"));
                isValid = false;
            }
            if (model.Seats < 2 || model.Seats > 6)
            {
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6!"));
                isValid = false;
            }
            if (model.Description.Length > 80)
            {
                errors.Add(new ErrorViewModel("Description must be less than 80 characters!"));
                isValid = false;
            }

            return (isValid, errors);
        }
    }
}

