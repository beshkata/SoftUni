﻿using Microsoft.AspNetCore.Mvc;
using MountainGuide.Core.Services.Contracts;
using MountainGuide.Core.Services.TouristBuilding.Models;
using MountainGuide.Models.TouristBuilding;

namespace MountainGuide.Controllers
{
    public class TouristBuildingController : Controller
    {
        private readonly ITouristBuildingService buildingService;

        public TouristBuildingController(
            ITouristBuildingService buildingService)
        {
            this.buildingService = buildingService;
        }
        public IActionResult All([FromQuery] AllTouristBuildingViewModel model)
        {

            model.Buildings = buildingService.GetAllBuildings(model.TypeFilter,
                model.MountainFilter,
                model.BuildingsPerPage,
                model.CurrentPage);
            model.Mountains = buildingService.GetAllMountains();
            model.BuildingTypes = buildingService.GetAllBuildingTypes();
            model.TotalBuildings = buildingService.GetAllBuildingsCount(model.TypeFilter, model.MountainFilter);

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var serviceModel = buildingService.GetBuildingDetails(id);

            if (serviceModel == null)
            {
                return NotFound();
            }
            return View(new TouristBuildingDetailsViewModel
            {
                TouristBuilding = serviceModel
            }); 
        }
    }
}