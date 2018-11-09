using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using js.pioneer.model;
using js.pioneer.utils;
using Microsoft.Extensions.Configuration;

namespace js.pioneer.repository
{
    public class SubscriptionContext
    {
        private readonly IMongoDatabase _database = null;
        private readonly IConfiguration config;

        public SubscriptionContext(IConfiguration config)
        {
            var client = new MongoClient(config["MongoConnection:ConnectionString"]);
            if (client != null)
                _database = client.GetDatabase(config["MongoConnection:Database"]);
        }

        public IMongoCollection<User> Users
        {
            get
            {
                return _database.GetCollection<User>("user");
            }
        }
    }
}
