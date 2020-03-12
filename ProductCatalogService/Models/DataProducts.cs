using ProductCatalogService.Interfaces;
using ProductCatalogService.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductCatalogService.Models
{
    public class DataProducts : DataSource, IProductsDb
    {
        public DataProducts()
        {
            db = new DataProductsContext();
        }

        public bool Delete(string idProduct)
        {
            try
            {
                var productInDb = db.Products.FirstOrDefault(p => p.Title == idProduct && p.IsEnabled == true);
                if (productInDb != null)
                    productInDb.IsEnabled = false;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public ProductDTO Insert(ProductDTO productDTO)
        {
            try
            {
                var productInserted = db.Products.Add(new Products
                {
                    Title = NewProductId(10, false, true, true, true),
                    Nombre = productDTO.Name,
                    Description = productDTO.Description,
                    Observations = Images.ByNameOrDefault(productDTO.Name),
                    PriceDistributor = USD,
                    PriceClient = productDTO.PriceUsd.Units,
                    PriceMember = productDTO.PriceUsd.Nanos,
                    Keywords = string.Join("-", productDTO.Categories),
                    DateUpdate = DateTime.Now,
                    IdCatalog = 3,
                    IsEnabled = true
                }).Entity;
                db.SaveChanges();

                productDTO.Id = productInserted.Title;
                return productDTO;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string NewProductId(int requiredLength, bool requireNonAlphanumeric, bool requireDigit, bool requireLowercase, bool requireUppercase)
        {
            int length = requiredLength;

            bool nonAlphanumeric = requireNonAlphanumeric;
            bool digit = requireDigit;
            bool lowercase = requireLowercase;
            bool uppercase = requireUppercase;

            StringBuilder password = new StringBuilder();
            Random random = new Random();

            while (password.Length < length)
            {
                char c = (char)random.Next(32, 126);

                password.Append(c);

                if (char.IsDigit(c))
                    digit = false;
                else if (char.IsLower(c))
                    lowercase = false;
                else if (char.IsUpper(c))
                    uppercase = false;
                else if (!char.IsLetterOrDigit(c))
                    nonAlphanumeric = false;
            }

            if (nonAlphanumeric)
                password.Append((char)random.Next(33, 48));
            if (digit)
                password.Append((char)random.Next(48, 58));
            if (lowercase)
                password.Append((char)random.Next(97, 123));
            if (uppercase)
                password.Append((char)random.Next(65, 91));

            return password.ToString();
        }

        public ProductDTO SelectById(string idProduct)
        {
            try
            {
                var productInDB = db.Products.FirstOrDefault(p => p.Title == idProduct && p.IsEnabled == true);
                if (productInDB != null)
                    return new ProductDTO
                    {
                        Id = productInDB.Title,
                        Name = productInDB.Nombre,
                        Description = productInDB.Description,
                        Picture = productInDB.Observations,
                        PriceUsd = new PriceDTO
                        {
                            CurrencyCode = "USD",
                            Units = int.Parse(productInDB.PriceClient.ToString()),
                            Nanos = int.Parse(productInDB.PriceMember.ToString())
                        },
                        Categories = productInDB.Keywords.Split("-").ToList()
                    };
                throw new Exception("Product not found");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PageDTO SelectByName(string name)
        {
            try
            {
                var ProductsInDb = db.Products
                    .Where(p => p.Nombre.Contains(name) && p.IsEnabled == true)
                    .Select(p => new ProductDTO {
                        Id = p.Title,
                        Name = p.Nombre,
                        Description = p.Description,
                        Picture = p.Observations,
                        PriceUsd = new PriceDTO
                        {
                            CurrencyCode = "USD",
                            Units = int.Parse(p.PriceClient.ToString()),
                            Nanos = int.Parse(p.PriceMember.ToString())
                        },
                        Categories = p.Keywords.Split('-', StringSplitOptions.None).ToList()
                    }).ToList();
                if (ProductsInDb != null)
                    return new PageDTO
                    {
                        TotalItems = ProductsInDb.Count(),
                        Products = ProductsInDb
                    };
                throw new Exception("NO Products found where match the name");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public PageDTO SelectPage(int page, int numItems)
        {
            try
            {
                int totalOfProducts = db.Products.Count();
                int totalPages = totalOfProducts / numItems;
                if (totalOfProducts % numItems > 0)
                    totalPages++;

                if (page > totalPages)
                    throw new Exception("Page number gater than total pages");

                var pageBuilded = db.Products
                    .Where(p => p.IsEnabled == true)
                    .OrderBy(p => p.Id)
                    .Skip(--page * numItems)
                    .Take(numItems)
                    .Select(p => new ProductDTO
                    {
                        Id = p.Title,
                        Name = p.Nombre,
                        Description = p.Description,
                        Picture = p.Observations,
                        PriceUsd = new PriceDTO
                        {
                            CurrencyCode = "USD",
                            Units = int.Parse(p.PriceClient.ToString()),
                            Nanos = int.Parse(p.PriceMember.ToString())
                        },
                        Categories = p.Keywords.Split('-', StringSplitOptions.None).ToList()
                    })
                    .ToList();
                return new PageDTO
                {
                    TotalItems = totalPages,
                    Products = pageBuilded
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public bool Update(ProductDTO product)
        {
            try
            {
                var productOnDb = db.Products.FirstOrDefault(p => p.Title == product.Id && p.IsEnabled == true);
                if (productOnDb != null)
                {
                    productOnDb.Nombre = product.Name;
                    productOnDb.Description = product.Description;
                    productOnDb.Observations = product.Picture;
                    productOnDb.PriceDistributor = USD;
                    productOnDb.PriceClient = product.PriceUsd.Units;
                    productOnDb.PriceMember = product.PriceUsd.Nanos;
                    productOnDb.Keywords = string.Join('-', product.Categories);

                    db.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
