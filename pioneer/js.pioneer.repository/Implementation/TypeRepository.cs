using js.pioneer.model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace js.pioneer.repository
{
    public class TypeRepository : ITypeRepository
    {
        private readonly SubscriptionContext _context = null;

        public TypeRepository(IConfiguration config)
        {
            _context = new SubscriptionContext(config);
        }

        public async Task Create(SubscriptionType model)
        {
            try
            {
                //inserting data
                await _context.SubscriptionTypes.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> Delete(int typeId)
        {
            try
            {
                var filter = Builders<SubscriptionType>.Filter.Eq("TypeId", typeId);
                return await _context.SubscriptionTypes.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<SubscriptionType>> GetAll()
        {
            try
            {
                return await _context.SubscriptionTypes.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SubscriptionType> Get(string typeId)
        {
            try
            {
                var filter = Builders<SubscriptionType>.Filter.Eq("TypeId", typeId);
                return await _context.SubscriptionTypes.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(SubscriptionType model)
        {
            try
            {
                var filter = Builders<SubscriptionType>.Filter.Eq("TypeId", model.TypeId);
                var type = _context.SubscriptionTypes.Find(filter).FirstOrDefaultAsync();
                if (type.Result == null)
                    return false;
                var update = Builders<SubscriptionType>.Update
                                              .Set(x => x.LoyaltyPoints, model.LoyaltyPoints);

                await _context.SubscriptionTypes.UpdateOneAsync(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
