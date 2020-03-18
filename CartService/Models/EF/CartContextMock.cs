using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models.EF
{
    public class CartContextMock : DataProductsContext
    {
        public CartContextMock()
        {
            List<Cart> mockCart = new List<Cart>();

            mockCart.Add(new Cart { idClient = "1", idProduct = "123", quantity = 3 });
            mockCart.Add(new Cart { idClient = "1", idProduct = "12", quantity = 3 });
            mockCart.Add(new Cart { idClient = "1", idProduct = "432", quantity = 3 });
            mockCart.Add(new Cart { idClient = "2", idProduct = "23", quantity = 3 });
            mockCart.Add(new Cart { idClient = "2", idProduct = "65", quantity = 3 });
            mockCart.Add(new Cart { idClient = "2", idProduct = "567", quantity = 3 });
            mockCart.Add(new Cart { idClient = "3", idProduct = "789", quantity = 3 });
            mockCart.Add(new Cart { idClient = "3", idProduct = "342", quantity = 3 });
            mockCart.Add(new Cart { idClient = "3", idProduct = "234", quantity = 3 });
            mockCart.Add(new Cart { idClient = "3", idProduct = "646", quantity = 3 });
            mockCart.Add(new Cart { idClient = "3", idProduct = "754", quantity = 3 });
            mockCart.Add(new Cart { idClient = "4", idProduct = "234", quantity = 3 });
            mockCart.Add(new Cart { idClient = "4", idProduct = "345", quantity = 3 });
            mockCart.Add(new Cart { idClient = "4", idProduct = "65", quantity = 3 });
            mockCart.Add(new Cart { idClient = "4", idProduct = "3456", quantity = 3 });

            foreach (var item in mockCart)
            {
                CatTypeDetails.Add(new EF.CatTypeDetails{
                    IdType = 1,
                    Code = item.idProduct,
                    Name = item.idClient,
                    Description = item.quantity.ToString()
                })
                ;
            }
            SaveChanges();
        }
    }
}
