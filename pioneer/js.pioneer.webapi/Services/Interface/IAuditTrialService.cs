using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using js.pioneer.model;

namespace js.pioneer.webapi
{
    public interface IAuditTrialService
    {
        Task Insert(string subscriptionNo,string message);
    }
}
