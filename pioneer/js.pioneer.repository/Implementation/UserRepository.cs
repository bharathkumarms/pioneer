using js.pioneer.model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace js.pioneer.repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SubscriptionContext _context = null;

        public UserRepository(IConfiguration config)
        {
            _context = new SubscriptionContext(config);
        }

        public User Authenticate(string username, string password)
        {
            try
            {
                var query = _context.Users
                            .Find(user => user.UserName == username);

                return query.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Create(User model)
        {
            try
            {
                //inserting data
                await _context.Users.InsertOneAsync(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DeleteResult> Delete(string userName)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq("UserName", userName);
                return await _context.Users.DeleteOneAsync(filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            try
            {
                return await _context.Users.Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<User> GetByUserName(string userName)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq("UserName", userName);
                return await _context.Users.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Update(User model)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq("UserName", model.UserName);
                var user = _context.Users.Find(filter).FirstOrDefaultAsync();
                if (user.Result == null)
                    return false;
                var update = Builders<User>.Update
                                              .Set(x => x.Password, model.Password);

                await _context.Users.UpdateOneAsync(filter, update);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
