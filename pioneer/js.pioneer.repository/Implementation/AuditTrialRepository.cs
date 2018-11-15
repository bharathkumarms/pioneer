using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using js.pioneer.model;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;

namespace js.pioneer.repository
{
    public class AuditTrialRepository : IAuditTrialRepository
    {
        private readonly SubscriptionContext _context = null;

        public AuditTrialRepository(IConfiguration config)
        {
            _context = new SubscriptionContext(config);
        }

        public async Task<IEnumerable<AuditTrial>> GetAllAuditTrials()
        {
            try
            {
                return await _context.AuditTrials.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AuditTrial>> GetAuditTrialBySubscriptionNo(string subscriptionNo)
        {
            try
            {
                var filter = Builders<AuditTrial>.Filter.Eq("SubscriptionNo", subscriptionNo);
                return await _context.AuditTrials.Find(filter).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Insert(AuditTrial model)
        {
            try
            {
                await _context.AuditTrials.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
