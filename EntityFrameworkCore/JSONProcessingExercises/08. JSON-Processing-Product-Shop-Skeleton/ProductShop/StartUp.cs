using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        static IMapper mapper;
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();



            //string userInputJson = File.ReadAllText("../../../Datasets/users.json");
            //string productInputJson = File.ReadAllText("../../../Datasets/products.json");
            //string categoryInputJson = File.ReadAllText("../../../Datasets/categories.json");
            //string categoryProductInputJson = File.ReadAllText("../../../Datasets/categories-products.json");
            //ImportUsers(context, userInputJson);
            //ImportProducts(context, productInputJson);
            //ImportCategories(context, categoryInputJson);
            //ImportCategoryProducts(context, categoryProductInputJson);
            string result = GetUsersWithProducts(context);

            Console.WriteLine(result);
        }

        //01. Import Users
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var dtoUsers = JsonConvert.DeserializeObject<ICollection<UserInputModel>>(inputJson);

            var users = mapper.Map<ICollection<User>>(dtoUsers);

            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count}";
        }

        //02. Import Products
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();

            var productsDto = JsonConvert.DeserializeObject<ICollection<ProductInputModel>>(inputJson);

            var products = mapper.Map<ICollection<Product>>(productsDto);

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count}";
        }

        //03. Import Categories
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeMapper();
            var categoriesDto = JsonConvert.DeserializeObject<ICollection<CategoryInputModel>>(inputJson)
                .Where(c => c.Name != null);

            var categories = mapper.Map<ICollection<Category>>(categoriesDto);

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Count}";
        }

        //04. Import Categories and Products
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeMapper();
            var categoryProductsDto = JsonConvert.DeserializeObject<ICollection<CategoryProductInputModel>>(inputJson);

            var categoryProducts = mapper.Map<ICollection<CategoryProduct>>(categoryProductsDto);

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();

            return $"Successfully imported {categoryProducts.Count}";
        }

        //05. Export Products In Range
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Include(s => s.Seller)
                .Select(product => new
                {
                    name = product.Name,
                    price = product.Price,
                    seller = product.Seller.FirstName + " " + product.Seller.LastName
                })
                .OrderBy(p => p.price)
                .ToList();

            string result = JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        //06. Export Sold Products
        public static string GetSoldProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(p => p.Buyer != null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            string result = JsonConvert.SerializeObject(usersWithSoldProducts, Formatting.Indented);

            return result;
        }

        //07. Export Categories By Products Count
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context
                .Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("F2")
                });
            return JsonConvert.SerializeObject(categories, Formatting.Indented);
        }

        //08. Export Users and Products
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var usersWithSoldProducts = context
                .Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .ToList()
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Count(),
                        products =
                            u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price.ToString("F2")
                            })
                            .ToList()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToList();

            var result = new
            {
                usersCount = usersWithSoldProducts.Count,
                users = usersWithSoldProducts
            };

            return JsonConvert.SerializeObject(result, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
        private static void InitializeMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }


    }
}