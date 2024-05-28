﻿using EventManagementApp.DTOs.User;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/")]
    [ApiController]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [Route("register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var customErrorResponse = new
                    {
                        Title = "One or more validation errors occurred.",
                        Errors = errors
                    };

                    return BadRequest(customErrorResponse);
                }

                await _authService.AddUser(registerDTO);
                return StatusCode(StatusCodes.Status201Created, "User created successfully");
            }
            catch (EmailAlreadyExistsException eafe)
            {
                return BadRequest(eafe.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                    var customErrorResponse = new
                    {
                        Status = 400,
                        Title = "One or more validation errors occurred.",
                        Errors = errors
                    };

                    return BadRequest(customErrorResponse);
                }

                LoginReturnDTO loginReturn = await _authService.Login(loginDTO);

                return Ok(loginReturn);

            }
            catch (InvalidEmailOrPasswordException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }


    }
}
