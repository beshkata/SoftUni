using CarShop.Common;
using CarShop.Contracts;
using CarShop.Data.Common;
using CarShop.Data.Models;
using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services
{
    public class IssueService : IIssueService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public IssueService(
            IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }

        public (bool isAdded, string error) AddIssue(AddIssueViewModel model)
        {
            bool isAdded = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            Issue issue = new Issue()
            {
                CarId = model.CarId,
                Description = model.Description,
                IsFixed = false
            };
            try
            {
                repo.Add(issue);
                repo.SaveChanges();
                isAdded = true;
            }
            catch (Exception)
            {
                error = ErrorMessages.UnexpectedErrorErrorMessage;
            }

            return (isAdded, error);
        }

        public IEnumerable<CarIssueViewModel> GetAllIssues(string carId)
        {
            return repo.All<Issue>()
                .Where(i => i.CarId == carId)
                .Select(i => new CarIssueViewModel
                {
                    CarId = i.CarId,
                    IssueId = i.Id,
                    Description = i.Description,
                    IsFixed = i.IsFixed ? "Yes" : "Not yet",
                })
                .ToList();
        }
    }
}
