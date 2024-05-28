using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/quotation")]
    [ApiController]
    public class QuotationController: ControllerBase
    {
        private readonly IQuotationRequestService _quotationRequestService;
        private readonly IQuotationResponseService _quotationResponseService;

        public QuotationController(IQuotationRequestService quotationRequestService, IQuotationResponseService quotationResponseService) 
        {
            _quotationRequestService = quotationRequestService;
            _quotationResponseService = quotationResponseService;
        }

        [HttpPost]
        [Authorize(Roles = "User")]
        [Route("request")]
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
            catch(NoEventCategoryFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [Route("response")]
        public async Task<IActionResult> CreateQuotationRequest(CreateQuotationResponseDTO createQuotationResponseDTO)
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

                await _quotationResponseService.CreateQuotationResponse(createQuotationResponseDTO);
                return StatusCode(StatusCodes.Status201Created, "Quotation Responded successfully");
            }
            catch (NoQuotationRequestFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (QuotationAlreadyRespondedException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AmountNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

    }
}
