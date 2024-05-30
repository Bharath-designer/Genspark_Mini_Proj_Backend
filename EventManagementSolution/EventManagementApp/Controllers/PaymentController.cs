using System.Diagnostics.CodeAnalysis;
using EventManagementApp.DTOs.Payment;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/payment")]
    [ApiController]
    [ExcludeFromCodeCoverage]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        [Route("{orderId}")]
        public async Task<IActionResult> MakePayment(int orderId)
        {
            try
            {
                int UserId = int.Parse(User.FindFirst("userId").Value.ToString());

                MakePaymentReturnDTO paymentResult = await _paymentService.MakePayment(UserId, orderId);
                return Ok(paymentResult);
            }
            catch (NoOrderFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(PaymentAlreadyCompletedException ex) 
            {
                return BadRequest(ex.Message);
            }
            catch (PaymentGatewayUnauthorizedException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }
        }

        [HttpPost]
        [Route("webhook")]
        [AllowAnonymous]
        public async Task<IActionResult> PaymentWebHook([FromBody] PaymentNotificationDTO paymentNotificationDTO)
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
                var headers = HttpContext.Request.Headers;

                await _paymentService.UpdateTransactionDetails(paymentNotificationDTO, headers);

                return Ok("Payment has been Updated");
            }
            catch(NoTransactionFoundException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
