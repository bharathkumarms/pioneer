using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using js.pioneer.model;
using js.pioneer.repository;
using MongoDB.Driver;

namespace js.pioneer.repository
{
    public interface ISubscriberRepository
    {
        Task<IEnumerable<Subscriber>> GetAllSubscribers();
        Task<Subscriber> GetSubscriber(string subscriptionNo);
        Task AddSubscriber(Subscriber model);
        Task<bool> UpdateSubscriber(Subscriber model);
        Task<DeleteResult> RemoveSubscriber(string subscriptionNo);
        Task<DeleteResult> RemoveAllSubscribers();

        Task<IEnumerable<Subscriber>> GetAllSubscribersInDateRange(DateTime startDate, DateTime endDate);
    }
}
