using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.DTOs.User;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/user/")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class UserController: ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("requests")]
        [HttpGet]
        public async Task<IActionResult> GetUserRequests()
        {
            try
            {
                int UserId = int.Parse(User.FindFirst("userId").Value.ToString());

                List<UserRequestListDTO> requests = await _userService.GetUserRequests(UserId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [Route("requests/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserRequests(int id)
        {
            try
            {
                int UserId = int.Parse(User.FindFirst("userId").Value.ToString());

                UserQuotationRequestDTO requests = await _userService.GetUserRequestById(UserId, id);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

        [Route("orders")]
        [HttpGet]
        public async Task<IActionResult> GetUserOrders()
        {
            try
            {
                int UserId = int.Parse(User.FindFirst("userId").Value.ToString());

                List<UserOrderListReturnDTO> requests = await _userService.GetUserOrders(UserId);
                return Ok(requests);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

    }
}
