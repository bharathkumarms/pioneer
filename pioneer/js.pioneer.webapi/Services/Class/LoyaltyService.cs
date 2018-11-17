using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using js.pioneer.repository;
using js.pioneer.model;
using js.pioneer.utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace js.pioneer.webapi
{
    public class LoyaltyService : ILoyaltyService
    {
        private ISubscriberRepository _subscriberRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<AuditTrialService> _log;

        public LoyaltyService(IOptions<AppSettings> appSettings,
            ILogger<AuditTrialService> log,
            ISubscriberRepository subscriberRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _subscriberRepository = subscriberRepository;
            _appSettings = appSettings.Value;
            _log = log;
        }

        public async Task<IEnumerable<LoyaltyDto>> GetLoyaltyReport(DateTime startDate, DateTime endDate)
        {
            try
            {
                return await BuildLoyalty(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IEnumerable<LoyaltyDto>> BuildLoyalty(DateTime startDate, DateTime endDate)
        {
            var subscribers = await _subscriberRepository.GetAllSubscribersInDateRange(startDate, endDate);
            return null;
        }
    }
}
