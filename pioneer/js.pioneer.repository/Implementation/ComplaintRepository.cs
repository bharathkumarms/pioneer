using js.pioneer.model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace js.pioneer.repository
{
    public class ComplaintRepository : IComplaintRepository
    {
        private readonly SubscriptionContext _context = null;

        public ComplaintRepository(IConfiguration config)
        {
            _context = new SubscriptionContext(config);
        }

        public async Task Create(Complaint model)
        {
            try
            {
                //inserting data
                await _context.Complaints.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> Delete(int complaintId)
        {
            try
            {
                var filter = Builders<Complaint>.Filter.Eq("ComplaintId", complaintId);
                return await _context.Complaints.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Complaint>> GetAll()
        {
            try
            {
                return await _context.Complaints.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Complaint> Get(int complaintId)
        {
            try
            {
                var filter = Builders<Complaint>.Filter.Eq("ComplaintId", complaintId);
                return await _context.Complaints.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(Complaint model)
        {
            try
            {
                var filter = Builders<Complaint>.Filter.Eq("ComplaintId", model.ComplaintId);
                var type = _context.Complaints.Find(filter).FirstOrDefaultAsync();
                if (type.Result == null)
                    return false;
                var update = Builders<Complaint>.Update
                                              .Set(x => x.Comments, model.Comments);

                await _context.Complaints.UpdateOneAsync(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
