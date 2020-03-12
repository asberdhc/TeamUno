using ProductCatalogService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogService.Models
{
    public class DataProductsMock : DataSource, IProductsDb
    {
        public bool Delete(string idProduct)
        {
            throw new NotImplementedException();
        }

        public ProductDTO Insert(ProductDTO product)
        {
            throw new NotImplementedException();
        }

        public ProductDTO SelectById(string idProduct)
        {
            throw new NotImplementedException();
        }

        public PageDTO SelectByName(string name)
        {
            throw new NotImplementedException();
        }

        public PageDTO SelectPage(int page, int numItems)
        {
            throw new NotImplementedException();
        }

        public bool Update(ProductDTO product)
        {
            throw new NotImplementedException();
        }
    }
}
