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
    public class ComplaintsController : Controller
    {
        private IComplaintRepository _complaintRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<ComplaintsController> _log;

        public ComplaintsController(
            IComplaintRepository complaintRepository,
            IOptions<AppSettings> appSettings,
            ILogger<ComplaintsController> log)
        {
            _complaintRepository = complaintRepository;
            _appSettings = appSettings.Value;
            _log = log;
        }

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> Get(int complaintId)
        {
            try
            {
                var complaint = await _complaintRepository.Get(complaintId);
                if (complaint == null)
                {
                    return Json(NotificationMessage.ComplaintGetNotfound);
                }
                return Json(complaint);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return Json(ex.ToString());
            }
        }

        [HttpGet]
        [Route("getall")]
        public Task<IEnumerable<Complaint>> Get()
        {
            try
            {
                return _complaintRepository.GetAll();
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> Post(Complaint model)
        {
            try
            {
                model.CreatedDate = DateTime.UtcNow;
                await _complaintRepository.Create(model);

                return Ok(NotificationMessage.ComplaintPostSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(Complaint model)
        {
            try
            {
                var result = await _complaintRepository.Update(model);
                if (result)
                {
                    return Ok(NotificationMessage.ComplaintUpdateSuccess);
                }
                return BadRequest(NotificationMessage.ComplaintUpdateErrorNotFound);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(int complaintId)
        {
            try
            {
                await _complaintRepository.Delete(complaintId);

                return Ok(NotificationMessage.ComplaintDeleteSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}