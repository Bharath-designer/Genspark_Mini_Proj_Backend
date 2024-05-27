using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/quotation/request")]
    [ApiController]
    public class QuotationRequestController: ControllerBase
    {
        private readonly IQuotationRequestService _quotationRequestService;

        public QuotationRequestController(IQuotationRequestService quotationRequestService) 
        {
            _quotationRequestService = quotationRequestService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateQuotationRequest(CreateQuotationRequestDTO createQuotationRequestDTO)
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

                int UserId = int.Parse(User.FindFirst("userId").Value.ToString());
                await _quotationRequestService.CreateQuotationRequest(UserId, createQuotationRequestDTO);
                return StatusCode(StatusCodes.Status201Created, "Request created successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }
        } 

    }
}
