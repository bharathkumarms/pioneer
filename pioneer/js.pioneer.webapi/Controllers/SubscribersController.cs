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
    public class SubscribersController : Controller
    {
        private ISubscriberRepository _subscriberRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<SubscribersController> _log;

        private IAuditTrialService _auditTrialService;
        private ICompareUtil _compareUtil;

        public SubscribersController(ISubscriberRepository subscriberRepository,
            IOptions<AppSettings> appSettings,
            ILogger<SubscribersController> log,
            IAuditTrialService auditTrialService,
            ICompareUtil compareUtil)
        {
            _subscriberRepository = subscriberRepository;
            _appSettings = appSettings.Value;
            _log = log;
            _auditTrialService = auditTrialService;
            _compareUtil = compareUtil;
        }
        [HttpGet]
        [Route("api/subscriber")]
        public Task<IEnumerable<Subscriber>> Get()
        {
            try
            {
                return _subscriberRepository.GetAllSubscribers();
            }
            catch(Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpGet]
        [Route("api/subscriber/getSubscriber")]
        public async Task<IActionResult> GetSubscriber(string subscriptionNo)
        {
            try
            {
                var Subscriber = await _subscriberRepository.GetSubscriber(subscriptionNo);
                if (Subscriber == null)
                {
                    return Json(NotificationMessage.SubscriberGetNotfound);
                }
                return Json(Subscriber);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return Json(ex.ToString());
            }

        }

        [HttpPost]
        [Route("api/subscriber")]
        public async Task<IActionResult> Post(Subscriber model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.CustomerName))
                    return BadRequest("Please enter Subscriber name");
                else if (string.IsNullOrWhiteSpace(model.Type.Name))
                    return BadRequest("Please enter type");
                else if (model.DueDate == null)
                    return BadRequest("Please enter due date");

                model.CreatedDate = DateTime.UtcNow;

                await _subscriberRepository.AddSubscriber(model);

                await _auditTrialService.Insert(model.SubscriptionNo, NotificationMessage.SubscriberPostSuccess);

                return Ok(NotificationMessage.SubscriberPostSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("api/subscriber/update")]
        public async Task<IActionResult> UpdateSubscriber(Subscriber model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.CustomerName))
                    return BadRequest("Subscriber name missing");
                model.ModifiedDate = DateTime.UtcNow;
                var subscriberBeforeUpdation = await _subscriberRepository.GetSubscriber(model.SubscriptionNo);

                var result = await _subscriberRepository.UpdateSubscriber(model);
                if (result)
                {
                    string changesDone = _compareUtil.Compare(subscriberBeforeUpdation, result);
                    await _auditTrialService.Insert(model.SubscriptionNo, NotificationMessage.SubscriberUpdateSuccess + ". " + changesDone);
                    return Ok(NotificationMessage.SubscriberUpdateSuccess);
                }
                return BadRequest(NotificationMessage.SubscriberUpdateErrorNotFound);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpDelete]
        [Route("api/subscriber")]
        public async Task<IActionResult> Delete(string subscriptionNo)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(subscriptionNo))
                    return BadRequest(NotificationMessage.SubscriberDeleteErrorNotFound);
                await _subscriberRepository.RemoveSubscriber(subscriptionNo);

                await _auditTrialService.Insert(subscriptionNo, NotificationMessage.SubscriberUpdateSuccess);
                return Ok(NotificationMessage.SubscriberDeleteSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
        [HttpDelete]
        [Route("api/subscriber/deleteAll")]
        public IActionResult DeleteAll()
        {
            try
            {
                _subscriberRepository.RemoveAllSubscribers();
                return Ok("Your all Subscribers has been deleted");
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

    }
}