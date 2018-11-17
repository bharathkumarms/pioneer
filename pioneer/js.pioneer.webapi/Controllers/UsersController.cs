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
    public class UsersController : Controller
    {
        private IUserRepository _userRepository;
        private readonly AppSettings _appSettings;
        readonly ILogger<UsersController> _log;

        public UsersController(
            IUserRepository userRepository,
            IOptions<AppSettings> appSettings,
            ILogger<UsersController> log)
        {
            _userRepository = userRepository;
            _appSettings = appSettings.Value;
            _log = log;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userDto)
        {
            try
            {
                var user = _userRepository.Authenticate(userDto.UserName, userDto.Password);

                if (user == null)
                    return BadRequest(new { message = "Username or password is incorrect" });

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.UserName.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                HttpContext.Session.SetObjectAsJson("User", user);

                // return basic user info (without password) and token to store client side
                return Ok(new
                {
                    Id = user.UserName,
                    Token = tokenString
                });
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return Ok(new Exception(ex.ToString()));
            }
        }

        [HttpGet]
        [Route("getbyusername")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            try
            {
                var user = await _userRepository.GetByUserName(userName);
                if (user == null)
                {
                    return Json(NotificationMessage.UserGetNotfound);
                }
                return Json(user);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return Json(ex.ToString());
            }
        }

        [HttpPost]
        [Route("user")]
        public async Task<IActionResult> Post(User model)
        {
            try
            {
                model.CreatedDate = DateTime.UtcNow;
                await _userRepository.Create(model);

                return Ok(NotificationMessage.UserPostSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(User model)
        {
            try
            {
                var result = await _userRepository.Update(model);
                if (result)
                {
                    return Ok(NotificationMessage.UserUpdateSuccess);
                }
                return BadRequest(NotificationMessage.UserUpdateErrorNotFound);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return null;
            }
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete(string userName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(userName))
                    return BadRequest(NotificationMessage.UserDeleteErrorNotFound);
                await _userRepository.Delete(userName);

                return Ok(NotificationMessage.UserDeleteSuccess);
            }
            catch (Exception ex)
            {
                _log.LogError(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}