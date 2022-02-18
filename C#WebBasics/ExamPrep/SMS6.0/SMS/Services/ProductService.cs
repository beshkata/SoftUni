using SMS.Common;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        private readonly IValidationService validationService;

        public ProductService(
            IRepository _repo,
            IValidationService _validationService)
        {
            repo = _repo;
            validationService = _validationService;
        }
        public (bool created, string error) Create(CreateViewModel model)
        {
            bool created = false;
            string error = null;

            var (isValid, validationError) = validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, validationError);
            }

            decimal price = 0;

            if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price)
                || price < GlobalConstants.ProductPriceMinValue 
                || price > GlobalConstants.ProductPriceMaxValue)
            {
                return (false, ErrorMessages.CreateProductPriceErrorMessage);
            }

            var product = new Product()
            {
                Name = model.Name,
                Price = price
            };

            try
            {
                repo.Add(product);
                repo.SaveChanges();
                created = true;
            }
            catch (Exception)
            {
                error = ErrorMessages.SaveProductErrorMessage;
            }

            return (created, error);
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(p => new ProductListViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2"),
                    ProductId = p.Id
                })
                .ToList();
        }
    }
}
