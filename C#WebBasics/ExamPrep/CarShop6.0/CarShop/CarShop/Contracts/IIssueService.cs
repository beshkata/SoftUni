using CarShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Contracts
{
    public interface IIssueService
    {
        public IEnumerable<CarIssueViewModel> GetAllIssues(string carId);

        public (bool isAdded, string error) AddIssue(AddIssueViewModel model);
    }
}
