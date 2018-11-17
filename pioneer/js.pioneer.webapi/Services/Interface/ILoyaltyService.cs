using js.pioneer.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace js.pioneer.webapi
{
    public interface ILoyaltyService
    {
        Task<IEnumerable<LoyaltyDto>> GetLoyaltyReport(DateTime startDate, DateTime endDate);
    }
}
