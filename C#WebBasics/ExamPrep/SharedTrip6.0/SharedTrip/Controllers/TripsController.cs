using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        public TripsController(Request request)
            : base(request)
        {
        }

        //[Authorize]
        public Response Add() => View();

        //[Authorize]
        public Response All()
        {
            return View();
        }

        //[Authorize]
        public Response Details() => View();   
    }
}
