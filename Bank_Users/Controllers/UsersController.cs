using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Users.App.Dtos;
using Users.App.Interfaces;
using Users.App.Services.Helpers;
using Newtonsoft.Json;
using System;
using Users.App.Validations;
using FluentValidation.Results;

namespace Bank_Users.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _service;
        private readonly RegisterUserValidator _registervalidator = new RegisterUserValidator();
        private readonly LoginUserValidator _loginValidator = new LoginUserValidator();

        public UsersController(IUserServices service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginDto, CancellationToken cancellationToken)
        {
            ValidationResult result = _loginValidator.Validate(loginDto);
            if (!result.IsValid) return BadRequest(result.Errors);

            try
            {
                DataResponseDto userRespose = await _service.Login(loginDto, cancellationToken);
                return Ok(userRespose);
            }
            catch (HandleErrors err)
            {
                return StatusCode(err.StatusCode, JsonConvert.SerializeObject(err));
            }
            catch(Exception)
            {
                return StatusCode(500, JsonConvert.SerializeObject(HandleErrors.InternalError()));
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerDto, CancellationToken cancellationToken)
        {
            ValidationResult result = _registervalidator.Validate(registerDto);
            if (!result.IsValid) return BadRequest(result.Errors);

            try
            {
                DataResponseDto userRespose = await _service.Register(registerDto, cancellationToken);
                return StatusCode(201, userRespose);
            }
            catch (HandleErrors err)
            {
                return StatusCode(err.StatusCode, JsonConvert.SerializeObject(err));
            }
            catch (Exception)
            {
                return StatusCode(500, JsonConvert.SerializeObject(HandleErrors.InternalError()));
            }
        }
    }
}
