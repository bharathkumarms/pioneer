using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using js.pioneer.model;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace js.pioneer.repository
{
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly SubscriptionContext _context = null;

        public SubscriberRepository(IConfiguration config)
        {
            _context = new SubscriptionContext(config);
        }

        public async Task<IEnumerable<Subscriber>> GetAllSubscribers()
        {
            return await _context.Subscribers.Find(x => true).ToListAsync();
        }

        public async Task<Subscriber> GetSubscriber(string subscriptionNo)
        {
            var filter = Builders<Subscriber>.Filter.Eq("SubscriptionNo", subscriptionNo);
            return await _context.Subscribers.Find(filter).FirstOrDefaultAsync();
        }
        public async Task AddSubscriber(Subscriber model)
        {
            //inserting data
            await _context.Subscribers.InsertOneAsync(model);
        }

        public async Task<bool> UpdateSubscriber(Subscriber model)
        {

            var filter = Builders<Subscriber>.Filter.Eq("SubscriptionNo", model.SubscriptionNo);
            var Subscriber = _context.Subscribers.Find(filter).FirstOrDefaultAsync();
            if (Subscriber.Result == null)
                return false;
            var update = Builders<Subscriber>.Update
                                          .Set(x => x.CustomerName, model.CustomerName)
                                          .Set(x => x.DueDate, model.DueDate);

            await _context.Subscribers.UpdateOneAsync(filter, update);
            return true;
        }

        public async Task<DeleteResult> RemoveSubscriber(string subscriptionNo)
        {
            var filter = Builders<Subscriber>.Filter.Eq("SubscriptionNo", subscriptionNo);
            return await _context.Subscribers.DeleteOneAsync(filter);
        }

        public Task<DeleteResult> RemoveAllSubscribers()
        {
            throw new NotImplementedException();
        }
    }
}