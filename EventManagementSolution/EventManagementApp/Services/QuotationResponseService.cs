using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Enums;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;

namespace EventManagementApp.Services
{
    public class QuotationResponseService: IQuotationResponseService
    {
        private readonly IQuotationRequestRepository _quotationRequestRepository;

        public QuotationResponseService(IQuotationRequestRepository quotationRequestRepository)
        {
            _quotationRequestRepository = quotationRequestRepository;
        }

        public async Task<int> CreateQuotationResponse(CreateQuotationResponseDTO createQuotationResponseDTO)
        {

            QuotationRequest quotationRequest = await _quotationRequestRepository.GetById(createQuotationResponseDTO.QuotationRequestId);

            if (quotationRequest == null)
            {
                throw new NoQuotationRequestFoundException();
            }

            if (quotationRequest.QuotationStatus == QuotationStatus.Responded)
            {
                throw new QuotationAlreadyRespondedException();
            }

            if (createQuotationResponseDTO.RequestStatus == RequestStatus.Accepted 
                && createQuotationResponseDTO.QuotedAmount == null)
            {
                throw new AmountNullException();
            } 

            QuotationResponse quotationResponse = new QuotationResponse();
            quotationResponse.QuotationRequestId = createQuotationResponseDTO.QuotationRequestId;
            quotationResponse.QuotedAmount = createQuotationResponseDTO.QuotedAmount;
            quotationResponse.ResponseMessage = createQuotationResponseDTO.ResponseMessage;
            quotationResponse.RequestStatus = createQuotationResponseDTO.RequestStatus;

            quotationRequest.QuotationStatus = QuotationStatus.Responded;
            quotationRequest.QuotationResponse = quotationResponse;

            await _quotationRequestRepository.Update(quotationRequest);
            return quotationResponse.QuotationResponseId;
        }
    }
}
