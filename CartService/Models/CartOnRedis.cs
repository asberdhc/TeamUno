using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public class CartOnRedis : RedisSource
    {
        public CartOnRedis(string server) : base(server) { }

        public override bool AddToCart(string idClient, string idProduct, int quantity)
        {
            var response = _database.HashIncrementAsync(idClient, idProduct, quantity);
            response.Wait();
            return response.Result >= 0;
        }

        public override Item DeleteFromCart(string idClient, string idProduct, int quantity)
        {
            if (_database.HashExists(idClient, idProduct))
            {
                var actualQuantity = _database.HashGet(idClient, idProduct).Box().ToString();
            }
            return new Item();
        }

        public override bool EmptyCart(string clientId)
        {
            var response = _database.KeyDelete(clientId);
            return response;
        }

        public override Cart GetById(string clientId)
        {
            var response = _database.HashGetAll(clientId);
            if (response != null)
            {
                Cart cart = new Cart();
                cart.idClient = clientId;
                cart.Items = response.Select(he =>
                    new Item { idProduct = he.Name, quantity = int.Parse(he.Value) }
                ).ToList();

                return cart;
            }
            throw new Exception(NOT_FOUND);
        }
    }
}
