using EventManagementApp.Enums;

namespace EventManagementApp.DTOs.QuotationRequest
{
    public class CreateQuotationResponseDTO
    {
        public int QuotationRequestId { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public double? QuotedAmount { get; set; }
        public string ResponseMessage { get; set; }
    }
}
