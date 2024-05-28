﻿using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;
using EventManagementApp.Exceptions;

namespace EventManagementApp.Services
{
    public class QuotationRequestService: IQuotationRequestService
    {
        private readonly IQuotationRequestRepository _quotationRequestRepository;
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public QuotationRequestService(IQuotationRequestRepository quotationRequestRepository, IEventCategoryRepository eventCategoryRepository) {
            _quotationRequestRepository = quotationRequestRepository;
            _eventCategoryRepository = eventCategoryRepository;
        }

        public async Task CreateQuotationRequest(int UserId, CreateQuotationRequestDTO quotationRequestDTO)
        {
            EventCategory eventCategory = await _eventCategoryRepository.GetById(quotationRequestDTO.EventCategoryId);

            if (eventCategory == null)
            {
                throw new NoEventCategoryFoundException();
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

            await _quotationRequestRepository.Add(request);
        }

    }
}
