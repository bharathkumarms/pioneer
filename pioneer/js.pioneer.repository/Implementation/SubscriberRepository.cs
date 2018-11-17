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
            try
            {
                return await _context.Subscribers.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Subscriber> GetSubscriber(string subscriptionNo)
        {
            try
            {
                var filter = Builders<Subscriber>.Filter.Eq("SubscriptionNo", subscriptionNo);
                return await _context.Subscribers.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task AddSubscriber(Subscriber model)
        {
            try
            {
                //inserting data
                await _context.Subscribers.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateSubscriber(Subscriber model)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> RemoveSubscriber(string subscriptionNo)
        {
            try
            {
                var filter = Builders<Subscriber>.Filter.Eq("SubscriptionNo", subscriptionNo);
                return await _context.Subscribers.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<DeleteResult> RemoveAllSubscribers()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Subscriber>> GetAllSubscribersInDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                var filterBuilder = Builders<Subscriber>.Filter;

                var filter = (filterBuilder.Gte(x => x.CreatedDate, startDate) &
                                filterBuilder.Lt(x => x.CreatedDate, endDate)) | 
                                (filterBuilder.Gte(x => x.RenewedDate, startDate) &
                                filterBuilder.Lt(x => x.RenewedDate, endDate));

                return await _context.Subscribers.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}