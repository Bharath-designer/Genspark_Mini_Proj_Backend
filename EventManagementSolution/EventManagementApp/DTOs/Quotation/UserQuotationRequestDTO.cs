using EventManagementApp.DTOs.Quotation;
using EventManagementApp.Enums;
using EventManagementApp.Models;

namespace EventManagementApp.DTOs.QuotationRequest
{
    public class UserQuotationRequestDTO : UserRequestListDTO
    {
        public UserQuotationResponseDTO QuotationResponse { get; set; }
    }
}
