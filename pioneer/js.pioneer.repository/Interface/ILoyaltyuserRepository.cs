using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using js.pioneer.model;
using js.pioneer.repository;
using MongoDB.Driver;

namespace js.pioneer.repository
{
    public interface ILoyaltyuserRepository
    {
        Task<IEnumerable<LoyaltyUser>> GetAll();
        Task<LoyaltyUser> Get(int loyaltyuserId);
        Task Create(LoyaltyUser model);
        Task<bool> Update(LoyaltyUser model);
        Task<DeleteResult> Delete(int loyaltyuserId);
    }
}
