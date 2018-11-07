using System;
using System.Collections.Generic;
using System.Text;
using js.pioneer.model;
using js.pioneer.repository;

namespace js.pioneer.repository
{
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
        User Create(User user, string password);
        void Update(User user, string password = null);
        void Delete(int id);
    }
}
