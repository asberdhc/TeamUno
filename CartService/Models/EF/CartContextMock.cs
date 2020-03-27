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
            List<Items> items = new List<Items>();
            items.Add(new Items { idProduct = "swev", quantity = 2 });
            items.Add(new Items { idProduct = "235432", quantity = 2 });
            items.Add(new Items { idProduct = "fvae", quantity = 2 });
            items.Add(new Items { idProduct = "24524", quantity = 2 });
            items.Add(new Items { idProduct = "sdfds", quantity = 2 });
            items.Add(new Items { idProduct = "23r32r", quantity = 2 });
            items.Add(new Items { idProduct = "sdffds", quantity = 2 });
            items.Add(new Items { idProduct = "fsdds", quantity = 2 });
            items.Add(new Items { idProduct = "32423", quantity = 2 });
            items.Add(new Items { idProduct = "fsdfdq", quantity = 2 });
            items.Add(new Items { idProduct = "fgdwe", quantity = 2 });
            items.Add(new Items { idProduct = "sdfdsf", quantity = 2 });
            items.Add(new Items { idProduct = "vsdv", quantity = 2 });
            items.Add(new Items { idProduct = "werw", quantity = 2 });
            items.Add(new Items { idProduct = "werewr", quantity = 1 });
            mockCart.Add(new Cart { idClient = "1",Items = items});
            mockCart.Add(new Cart { idClient = "2",Items = items});
            mockCart.Add(new Cart { idClient = "3",Items = items});
            mockCart.Add(new Cart { idClient = "4",Items = items});
            mockCart.Add(new Cart { idClient = "5",Items = items});
            mockCart.Add(new Cart { idClient = "6",Items = items});
                foreach (var item in mockCart)
                {
                foreach (var itemItem in items)
                {
                    CatTypeDetails.Add(new EF.CatTypeDetails
                    {
                        IdType = 1,
                        Code = itemItem.idProduct,
                        Name = item.idClient,
                        Description = itemItem.quantity.ToString()
                    })
                    ;
                }
                    
                }
                SaveChanges();
            }
        }
    }

