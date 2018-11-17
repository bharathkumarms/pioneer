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
    public class AuditTrialService : IAuditTrialService
    {
        private IAuditTrialRepository _auditTrialRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<AuditTrialService> _log;

        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public AuditTrialService(IOptions<AppSettings> appSettings,
            ILogger<AuditTrialService> log,
            IAuditTrialRepository auditTrialRepository,
            IHttpContextAccessor httpContextAccessor)
        {
            _auditTrialRepository = auditTrialRepository;
            _appSettings = appSettings.Value;
            _log = log;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Insert(string subscriptionNo, string message)
        {
            try
            {
                await _auditTrialRepository.Insert(BuildAuditTrialObject(subscriptionNo, message));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private AuditTrial BuildAuditTrialObject(string subscriptionNo, string message)
        {
            try
            {
                var user = _session.GetObjectFromJson<User>("User");

                var modal = new AuditTrial
                {
                    Date = DateTime.UtcNow,
                    Description = message,
                    SubscriptionNo = subscriptionNo,
                    UserNameWhoUpdated = user.UserName
                };

                return modal;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
