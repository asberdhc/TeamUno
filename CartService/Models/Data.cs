using CartService.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CartService.Models
{
    public class Data
    {
        DataProductsContext db = new DataProductsContext();

        public bool AddtoCart(Cart cart)
        {
            try
            {
                CatTypeDetails catTypeDetails = new CatTypeDetails
                {
                    Code = cart.idProduct.ToString(),
                    Name = cart.idClient.ToString(),
                    Description = cart.quantity.ToString()
                };
                db.CatTypeDetails.Add(catTypeDetails);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public List<Cart> GetCartById(string id)
        {
            List<Cart> cartList = new List<Cart>();
            var cart = db.CatTypeDetails
                .Where(p => p.Name == id)
                .Select(p => new Cart
                {
                    idClient = p.Name,
                    idProduct = p.Code,
                    quantity = Int32.Parse(p.Description)
                }
                );
            cartList.AddRange(cart);
            return cartList;
        }

        public bool EmptyCart(string id)
        {
            var result = from c in db.CatTypeDetails
                .Where(c => c.Name == id)
                         select c;

            foreach (var item in result)
            {
                db.CatTypeDetails.Remove(item);
            }
            try
            {
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

    }
}
