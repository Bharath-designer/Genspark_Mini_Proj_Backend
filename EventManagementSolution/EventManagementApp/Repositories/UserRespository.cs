﻿using EventManagementApp.Context;
using EventManagementApp.DTOs.ClientResponse;
using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.DTOs.Quotation;
using EventManagementApp.DTOs.QuotationRequest;
using EventManagementApp.DTOs.User;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagementApp.Repositories
{
    public class UserRespository : Repository<User, int>, IUserRepository
    {
        public UserRespository(EventManagementDBContext context) : base(context) { }

        public async Task<User> GetUserByEmail(string email)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<User> GetUserByEmailWithUserCredential(string email)
        {
            User? user = await _context.Users.Include(u => u.UserCredential).FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }

        public async Task<UserQuotationRequestDTO> GetUserRequestById(int userId, int quotationRequestId)
        {
#pragma warning disable CS8601 // Possible null reference assignment.
            UserQuotationRequestDTO? userQuotationRequestDTO = await _context.QuotationRequests
                .Where(q => q.UserId == userId && q.QuotationRequestId == quotationRequestId)
                .Select(q => new UserQuotationRequestDTO
                {
                    QuotationRequestId = q.QuotationRequestId,
                    VenueType = q.VenueType,
                    LocationDetails = q.LocationDetails,
                    FoodPreference = q.FoodPreference,
                    CateringInstructions = q.CateringInstructions,
                    SpecialInstructions = q.SpecialInstructions,
                    QuotationStatus = q.QuotationStatus,
                    EventStartDate = q.EventStartDate,
                    EventEndDate = q.EventEndDate,
                    RequestDate = q.RequestDate,
                    QuotationResponse = q.QuotationResponse != null ? new UserQuotationResponseDTO
                    {
                        QuotationResponseId = q.QuotationResponse.QuotationResponseId,
                        RequestStatus = q.QuotationResponse.RequestStatus,
                        QuotedAmount = q.QuotationResponse.QuotedAmount,
                        ResponseMessage = q.QuotationResponse.ResponseMessage,
                        ResponseDate = q.QuotationResponse.ResponseDate,
                        ClientResponse = q.QuotationResponse.ClientResponse != null ? new ClientResponseDecisionDTO
                        {
                            ClientDecision = q.QuotationResponse.ClientResponse.ClientDecision,
                            OrderId = q.QuotationResponse.ClientResponse.Order.OrderId
                        } : null,
                    } : null
                })
                .FirstOrDefaultAsync();
#pragma warning restore CS8601 // Possible null reference assignment.
            return userQuotationRequestDTO;
        }

        public async Task<List<UserRequestListDTO>> GetUserRequests(int userId)
        {
            List<UserRequestListDTO> quotationRequest = await _context
                .QuotationRequests
                .Where(q => q.UserId == userId)
                .Select(q => new UserRequestListDTO
                {
                    QuotationRequestId = q.QuotationRequestId,
                    VenueType = q.VenueType,
                    LocationDetails = q.LocationDetails,
                    FoodPreference = q.FoodPreference,
                    CateringInstructions = q.CateringInstructions,
                    SpecialInstructions = q.SpecialInstructions,
                    QuotationStatus = q.QuotationStatus,
                    EventStartDate = q.EventStartDate,
                    EventEndDate = q.EventEndDate,
                    RequestDate = q.RequestDate
                })
                .ToListAsync();

            return quotationRequest;
        }

        public async Task<List<UserOrderListReturnDTO>> GetUserOrders(int userId)
        {
            List<UserOrderListReturnDTO> userOrders = await _context.Orders
                .Where(o => o.UserId == userId)
                .Select(o => new UserOrderListReturnDTO
                {
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate,
                    OrderStatus = o.OrderStatus,
                    TotalAmount = o.TotalAmount,
                    EventCategory = new BaseEventCategoryDTO
                    {
                        EventCategoryId = o.EventCategory.EventCategoryId,
                        EventName = o.EventCategory.EventName,
                        Description = o.EventCategory.Description,
                        CreatedDate = o.EventCategory.CreatedDate
                    }
                })
                .ToListAsync();
            return userOrders;
        }

    }
}