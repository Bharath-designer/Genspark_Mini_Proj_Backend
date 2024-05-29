﻿using System.Collections.Generic;
using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Interfaces.Service;
using EventManagementApp.Models;
using EventManagementApp.Repositories;

namespace EventManagementApp.Services
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly IEventCategoryRepository _eventCategoryRepository;

        public EventCategoryService(IEventCategoryRepository eventCategoryRepository)
        {
            _eventCategoryRepository = eventCategoryRepository;
        }
        

        public async Task<List<BaseEventCategoryDTO>> GetAllEventCategories()
        {
            var events = await _eventCategoryRepository.GetAllActiveWithReviews();
            return events;
        }
    }
}
