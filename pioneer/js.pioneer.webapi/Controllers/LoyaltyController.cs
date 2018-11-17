using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using js.pioneer.repository;
using js.pioneer.model;
using js.pioneer.utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace js.pioneer.webapi
{
    public class LoyaltyController : Controller
    {
        private ILoyaltyService _loyaltyService;
        private readonly AppSettings _appSettings;
        readonly ILogger<LoyaltyController> _log;

        private IAuditTrialService _auditTrialService;

        public LoyaltyController(ILoyaltyService loyaltyService,
            IOptions<AppSettings> appSettings,
            ILogger<LoyaltyController> log,
            IAuditTrialService auditTrialService)
        {
            _loyaltyService = loyaltyService;
            _appSettings = appSettings.Value;
            _log = log;
            _auditTrialService = auditTrialService;
        }

        [HttpGet]
        [Route("api/loyaltyreport")]
        public Task<IEnumerable<LoyaltyDto>> Get(DateTime startDate, DateTime endDate)
        {
            try
            {
                return _loyaltyService.GetLoyaltyReport(startDate, endDate);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }
    }
}
