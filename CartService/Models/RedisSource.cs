using CartService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CartService.Models
{
    public abstract class RedisSource
    {
        public const string NOT_FOUND = "Not Found";
        protected readonly IDatabase _database;

        public RedisSource(string server)
        {
            _database = ConnectionMultiplexer.Connect(server).GetDatabase();
        }

        public abstract bool AddToCart(string idClient, string idProduct, int quantity);

        public abstract Item DeleteFromCart(string idClient, string idProduct, int quantity);

        public abstract bool EmptyCart(string clientId);

        public abstract Cart GetById(string clientId);
    }
}
