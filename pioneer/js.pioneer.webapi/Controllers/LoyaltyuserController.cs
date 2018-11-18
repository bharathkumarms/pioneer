using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.IdentityModel.Tokens.Jwt;
using js.pioneer.utils;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using js.pioneer.model;
using js.pioneer.repository;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace js.pioneer.webapi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class LoyaltyuserController : Controller
    {
        private ILoyaltyuserRepository _loyaltyuserRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<LoyaltyuserController> _log;

        public LoyaltyuserController(
            ILoyaltyuserRepository loyaltyuserRepository,
            IOptions<AppSettings> appSettings,
            ILogger<LoyaltyuserController> log)
        {
            _loyaltyuserRepository = loyaltyuserRepository;
            _appSettings = appSettings.Value;
            _log = log;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(int loyaltyuserId)
        {
            try
            {
                var loyaltyuser = await _loyaltyuserRepository.Get(loyaltyuserId);
                if (loyaltyuser == null)
                {
                    return Json(NotificationMessage.LoyaltyuserGetNotfound);
                }
                return Json(loyaltyuser);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return Json(ex.ToString());
            }
        }

        [HttpGet]
        [Route("getall")]
        public Task<IEnumerable<LoyaltyUser>> Get()
        {
            try
            {
                return _loyaltyuserRepository.GetAll();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> Post(LoyaltyUser model)
        {
            try
            {
                model.CreatedDate = DateTime.UtcNow;
                await _loyaltyuserRepository.Create(model);

                return Ok(NotificationMessage.LoyaltyuserPostSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(LoyaltyUser model)
        {
            try
            {
                var result = await _loyaltyuserRepository.Update(model);
                if (result)
                {
                    return Ok(NotificationMessage.LoyaltyuserUpdateSuccess);
                }
                return BadRequest(NotificationMessage.LoyaltyuserUpdateErrorNotFound);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int loyaltyuserId)
        {
            try
            {
                await _loyaltyuserRepository.Delete(loyaltyuserId);

                return Ok(NotificationMessage.LoyaltyuserDeleteSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}