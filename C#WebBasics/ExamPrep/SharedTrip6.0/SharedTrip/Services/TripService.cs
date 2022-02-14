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
                Description = model.Description,
                Seats = model.Seats
            };

            await _repo.AddAsync(trip);
            await _repo.SaveChangesAsync();
        }

        public void AddUserToTrip(string tripId, string id)
        {
            User user = _repo.All<User>()
                .FirstOrDefault(u => u.Id == id);
            Trip trip = _repo.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or trip not found!");
            }

            UserTrip userTrip = new UserTrip
            {
                TripId = trip.Id,
                Trip = trip,
                UserId = user.Id,
                User = user
            };
            trip.Seats -= 1;

            _repo.AddAsync(userTrip);
            _repo.SaveChangesAsync();
        }

        public IEnumerable<AllTripViewModel> GetAllTrips()
        {
            return _repo
                .All<Trip>()
                .Select(t => new AllTripViewModel
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats
                });
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
        {
            return _repo
                .All<Trip>()
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel
                {
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Description = t.Description,
                    Seats = t.Seats,
                    Id = t.Id,
                    ImagePath = t.ImagePath
                })
                .FirstOrDefault();
                
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

