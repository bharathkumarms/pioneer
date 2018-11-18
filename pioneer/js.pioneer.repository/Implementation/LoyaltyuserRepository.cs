using js.pioneer.model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace js.pioneer.repository
{
    public class LoyaltyuserRepository : ILoyaltyuserRepository
    {
        private readonly SubscriptionContext _context = null;

        public LoyaltyuserRepository(IConfiguration config)
        {
            _context = new SubscriptionContext(config);
        }

        public async Task Create(LoyaltyUser model)
        {
            try
            {
                //inserting data
                await _context.LoyaltyUsers.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> Delete(int loyaltyuserId)
        {
            try
            {
                var filter = Builders<LoyaltyUser>.Filter.Eq("LoyaltyUserId", loyaltyuserId);
                return await _context.LoyaltyUsers.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<LoyaltyUser>> GetAll()
        {
            try
            {
                return await _context.LoyaltyUsers.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<LoyaltyUser> Get(int loyaltyuserId)
        {
            try
            {
                var filter = Builders<LoyaltyUser>.Filter.Eq("LoyaltyUserId", loyaltyuserId);
                return await _context.LoyaltyUsers.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(LoyaltyUser model)
        {
            try
            {
                var filter = Builders<LoyaltyUser>.Filter.Eq("LoyaltyUserId", model.LoyaltyUserId);
                var type = _context.LoyaltyUsers.Find(filter).FirstOrDefaultAsync();
                if (type.Result == null)
                    return false;
                var update = Builders<LoyaltyUser>.Update
                                              .Set(x => x.Name, model.Name);

                await _context.LoyaltyUsers.UpdateOneAsync(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
