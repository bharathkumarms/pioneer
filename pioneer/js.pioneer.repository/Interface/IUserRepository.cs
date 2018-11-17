using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using js.pioneer.model;
using js.pioneer.repository;
using MongoDB.Driver;

namespace js.pioneer.repository
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();
        Task<User> GetByUserName(string userName);
        Task Create(User model);
        Task<bool> Update(User model);
        Task<DeleteResult> Delete(string userName);
    }
}
