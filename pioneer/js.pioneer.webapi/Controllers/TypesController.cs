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
    public class TypesController : Controller
    {
        private ITypeRepository _typeRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<TypesController> _log;

        public TypesController(
            ITypeRepository typeRepository,
            IOptions<AppSettings> appSettings,
            ILogger<TypesController> log)
        {
            _typeRepository = typeRepository;
            _appSettings = appSettings.Value;
            _log = log;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(string typeId)
        {
            try
            {
                var type = await _typeRepository.Get(typeId);
                if (type == null)
                {
                    return Json(NotificationMessage.TypeGetNotfound);
                }
                return Json(type);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return Json(ex.ToString());
            }
        }

        [HttpGet]
        [Route("getall")]
        public Task<IEnumerable<SubscriptionType>> Get()
        {
            try
            {
                return _typeRepository.GetAll();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> Post(SubscriptionType model)
        {
            try
            {
                model.CreatedDate = DateTime.UtcNow;
                await _typeRepository.Create(model);

                return Ok(NotificationMessage.TypePostSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(SubscriptionType model)
        {
            try
            {
                var result = await _typeRepository.Update(model);
                if (result)
                {
                    return Ok(NotificationMessage.TypeUpdateSuccess);
                }
                return BadRequest(NotificationMessage.TypeUpdateErrorNotFound);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int typeId)
        {
            try
            {
                await _typeRepository.Delete(typeId);

                return Ok(NotificationMessage.TypeDeleteSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}