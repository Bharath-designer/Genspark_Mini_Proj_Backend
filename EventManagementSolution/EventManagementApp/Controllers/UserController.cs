﻿using EventManagementApp.DTOs;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _useService;

        public UserController(IUserService useService)
        {
            _useService = useService;
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

                await _useService.AddUser(registerDTO);
                return StatusCode(StatusCodes.Status201Created, "User created successfully");
            }
            catch (EmailAlreadyExistsException eafe)
            {
                return BadRequest(eafe.Message);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        //[Route("login")]
        //[HttpPost]
        //public async Task<IActionResult> Login()
        //{

        //}
    }
}
