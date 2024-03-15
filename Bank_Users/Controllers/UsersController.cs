using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.App.Dtos;
using Users.App.Interfaces;
using Users.App.Services.Helpers;
using Newtonsoft.Json;
using System;

namespace Bank_Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _service;

        public UsersController(IUserServices service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginDto, CancellationToken cancellationToken)
        {
            try
            {
                DataResponseDto userRespose = await _service.Login(loginDto, cancellationToken);
                return Ok(userRespose);
            }
            catch (HandleErrors err)
            {
                return StatusCode(err.StatusCode, JsonConvert.SerializeObject(err));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto, CancellationToken cancellationToken)
        {
            try
            {
                DataResponseDto userRespose = await _service.Register(registerDto, cancellationToken);
                return StatusCode(201, userRespose);
            }
            catch (HandleErrors err)
            {
                return StatusCode(err.StatusCode, JsonConvert.SerializeObject(err));
            }
        }
    }
}
