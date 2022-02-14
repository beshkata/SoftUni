using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Identity;
using SharedTrip.Contracts;
using SharedTrip.Models;
using SharedTrip.Models.TripViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripService _tripService;
        public TripsController(Request request, ITripService tripService)
            : base(request)
        {
            _tripService = tripService;
        }

        //[Authorize]
        public Response Add() => View();

        [HttpPost]
        public Response Add(AddTripViewModel model)
        {
            var (isValid, errors) = _tripService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                _tripService.AddTripAsync(model);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error") }, "/Error");
            }
            return Redirect("/Trips/All");
        }

        //[Authorize]
        public Response All()
        {
            return View();
        }

        //[Authorize]
        public Response Details() => View();   
    }
}
