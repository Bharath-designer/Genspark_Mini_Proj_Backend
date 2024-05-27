using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApp.Controllers
{
    [Route("api/quotation/response")]
    [ApiController]
    public class QuotationResponseController : ControllerBase
    {
        private readonly IQuotationResponseService _quotationResponseService;

        public QuotationResponseController(IQuotationResponseService quotationResponseService)
        {
            _quotationResponseService = quotationResponseService;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
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
            catch(NoQuotationRequestFoundException ex)
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
