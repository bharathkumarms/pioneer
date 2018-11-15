using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using js.pioneer.repository;
using js.pioneer.model;
using js.pioneer.utils;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace js.pioneer.webapi.Controllers
{
    public class AuditTrialsController : Controller
    {
        private IAuditTrialRepository _auditTrialRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<AuditTrialsController> _log;

        public AuditTrialsController(IAuditTrialRepository auditTrialRepository,
            IOptions<AppSettings> appSettings,
            ILogger<AuditTrialsController> log)
        {
            _auditTrialRepository = auditTrialRepository;
            _appSettings = appSettings.Value;
            _log = log;
        }

        [HttpGet]
        [Route("api/audittrial")]
        public Task<IEnumerable<AuditTrial>> Get()
        {
            try
            {
                return _auditTrialRepository.GetAllAuditTrials();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpGet]
        [Route("api/audittrial/subscriptionno")]
        public Task<IEnumerable<AuditTrial>> Get(string subscriptionNo)
        {
            try
            {
                return _auditTrialRepository.GetAuditTrialBySubscriptionNo(subscriptionNo);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }
    }
}