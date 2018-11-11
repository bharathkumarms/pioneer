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

        public User Create(User user, string password)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(User user, string password = null)
        {
            throw new NotImplementedException();
        }
    }
}
