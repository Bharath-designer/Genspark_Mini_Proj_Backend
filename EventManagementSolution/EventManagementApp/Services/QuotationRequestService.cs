using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;
using EventManagementApp.Exceptions;
using EventManagementApp.Repositories;
using Microsoft.EntityFrameworkCore;
using EventManagementApp.Context;

namespace EventManagementApp.Services
{
    public class QuotationRequestService : IQuotationRequestService
    {
        private readonly IQuotationRequestRepository _quotationRequestRepository;
        private readonly IEventCategoryRepository _eventCategoryRepository;
        private readonly INotificationService _notificationService;
        private readonly IUserRepository _userRepository;
        private readonly EventManagementDBContext _context;

        public QuotationRequestService(IQuotationRequestRepository quotationRequestRepository,
            IEventCategoryRepository eventCategoryRepository,
            INotificationService notificationService,
            IUserRepository userRepository,
            EventManagementDBContext context
            )
        {
            _quotationRequestRepository = quotationRequestRepository;
            _eventCategoryRepository = eventCategoryRepository;
            _notificationService = notificationService;
            _userRepository = userRepository;
            _context = context;
        }

        public async Task<int> CreateQuotationRequest(int UserId, CreateQuotationRequestDTO quotationRequestDTO)
        {
            EventCategory eventCategory = await _eventCategoryRepository.GetById(quotationRequestDTO.EventCategoryId);

            if (eventCategory == null)
            {
                throw new NoEventCategoryFoundException();
            }

            if (!eventCategory.IsActive)
            {
                throw new EventInActiveException();
            }

            QuotationRequest request = new QuotationRequest();

            request.UserId = UserId;
            request.EventCategoryId = quotationRequestDTO.EventCategoryId;
            request.VenueType = quotationRequestDTO.VenueType;
            request.FoodPreference = quotationRequestDTO.FoodPreference;
            request.LocationDetails = quotationRequestDTO.LocationDetails;
            request.CateringInstructions = quotationRequestDTO.CateringInstructions;
            request.SpecialInstructions = quotationRequestDTO.SpecialInstructions;
            request.EventStartDate = quotationRequestDTO.EventStartDate;
            request.EventEndDate = quotationRequestDTO.EventEndDate;


            using (var DBTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _quotationRequestRepository.Add(request);

                    string notificationMsg = $"A New Quotation request is raised for {eventCategory.EventName}";
                    int adminId = await _userRepository.GetAdminUserId();

                    string sourceURL = $"/api/admin/quotations?isnew=true&requestId={request.QuotationRequestId}";
                    await _notificationService.CreateNotification(adminId, notificationMsg, sourceURL);

                    await DBTransaction.CommitAsync();

                    return request.QuotationRequestId;
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
