using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using js.pioneer.model;
using js.pioneer.repository;
using MongoDB.Driver;

namespace js.pioneer.repository
{
    public interface IAuditTrialRepository
    {
        Task<IEnumerable<AuditTrial>> GetAllAuditTrials();
        Task<IEnumerable<AuditTrial>> GetAuditTrialBySubscriptionNo(string subscriptionNo);
        Task Insert(AuditTrial model);
    }
}
