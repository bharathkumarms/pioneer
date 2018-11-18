using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using js.pioneer.model;
using js.pioneer.repository;
using MongoDB.Driver;

namespace js.pioneer.repository
{
    public interface ITypeRepository
    {
        Task<IEnumerable<SubscriptionType>> GetAll();
        Task<SubscriptionType> Get(string typeId);
        Task Create(SubscriptionType model);
        Task<bool> Update(SubscriptionType model);
        Task<DeleteResult> Delete(int typeId);
    }
}
