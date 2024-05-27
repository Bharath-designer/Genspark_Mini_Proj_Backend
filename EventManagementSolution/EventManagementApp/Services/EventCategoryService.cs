using System.Collections.Generic;
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
        public async Task CreateEventCategory(CreateEventCategoryDTO eventCategoryDTO)
        {
            EventCategory category = new EventCategory();
            category.EventName = eventCategoryDTO.EventName;
            category.Description = eventCategoryDTO.Description;
            await _eventCategoryRepository.Add(category);
        }

        public async Task<List<BaseEventCategoryDTO>> GetAllEventCategories()
        {
            List <EventCategory> events = await _eventCategoryRepository.GetAll();
            List<BaseEventCategoryDTO> eventCategoryDTOs = events
                .Select(ec => new BaseEventCategoryDTO
                {
                    EventCategoryId = ec.EventCategoryId,
                    EventName = ec.EventName,
                    Description = ec.Description,
                    CreatedDate = ec.CreatedDate
                })
                .ToList();

            return eventCategoryDTOs;
        }
    }
}
