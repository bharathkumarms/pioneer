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

        public SubscribersController(ISubscriberRepository subscriberRepository,
            IOptions<AppSettings> appSettings,
            ILogger<SubscribersController> log)
        {
            _subscriberRepository = subscriberRepository;
            _appSettings = appSettings.Value;
            _log = log;
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
                    return Json("No Subscriber found!");
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
                return Ok("Your Subscriber has been added successfully");
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
                var result = await _subscriberRepository.UpdateSubscriber(model);
                if (result)
                {
                    return Ok("Your Subscriber's details has been updated successfully");
                }
                return BadRequest("No Subscriber found to update");
            }catch(Exception ex)
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
                    return BadRequest("Subscriber number missing");
                await _subscriberRepository.RemoveSubscriber(subscriptionNo);
                return Ok("Your Subscriber has been deleted successfully");
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