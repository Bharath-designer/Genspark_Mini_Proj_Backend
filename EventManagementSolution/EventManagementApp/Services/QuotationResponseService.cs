using EventManagementApp.Context;
using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Enums;
using EventManagementApp.Exceptions;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;
using EventManagementApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Services
{
    public class QuotationResponseService: IQuotationResponseService
    {
        private readonly IQuotationRequestRepository _quotationRequestRepository;
        private readonly INotificationService _notificationService;
        private readonly EventManagementDBContext _context;

        public QuotationResponseService(IQuotationRequestRepository quotationRequestRepository,
            INotificationService notificationService,
            EventManagementDBContext context

            )
        {
            _quotationRequestRepository = quotationRequestRepository;
            _notificationService = notificationService;
            _context = context;
        }

        public async Task<int> CreateQuotationResponse(CreateQuotationResponseDTO createQuotationResponseDTO)
        {

            QuotationRequest quotationRequest = await _quotationRequestRepository.GetById((int)createQuotationResponseDTO.QuotationRequestId);

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

            if (createQuotationResponseDTO.RequestStatus == RequestStatus.Accepted
                && createQuotationResponseDTO.Currency == null)
            {
                throw new CurrencyNullException();
            }

            QuotationResponse quotationResponse = new QuotationResponse();
            quotationResponse.QuotationRequestId = (int)createQuotationResponseDTO.QuotationRequestId;
            quotationResponse.QuotedAmount = createQuotationResponseDTO.QuotedAmount;
            quotationResponse.Currency = (Currency)createQuotationResponseDTO.Currency;
            quotationResponse.ResponseMessage = createQuotationResponseDTO.ResponseMessage;
            quotationResponse.RequestStatus = createQuotationResponseDTO.RequestStatus;

            quotationRequest.QuotationStatus = QuotationStatus.Responded;
            quotationRequest.QuotationResponse = quotationResponse;

            using (var DBTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {

                    await _quotationRequestRepository.Update(quotationRequest);

                    string NotificatinMsg = $"Admin responded to your Quotation request";
                    string sourceURL = $"/api/user/requests/{quotationRequest.QuotationRequestId}";

                    await _notificationService.CreateNotification(quotationRequest.UserId, NotificatinMsg, sourceURL);

                    await DBTransaction.CommitAsync();
                    return quotationResponse.QuotationResponseId;
                }
                catch (Exception ex)
                {
                    await DBTransaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
