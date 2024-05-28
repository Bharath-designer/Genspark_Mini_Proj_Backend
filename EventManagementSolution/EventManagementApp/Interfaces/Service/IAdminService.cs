using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.DTOs.ScheduledEvent;
using EventManagementApp.Exceptions;

namespace EventManagementApp.Interfaces.Service
{
    public interface IAdminService
    {
        public Task CreateEventCategory(CreateEventCategoryDTO eventCategoryDTO);
        public Task<List<AdminScheduledEventListDTO>> GetScheduledEvents();
        /// <exception cref="NoEventCategoryFoundException"/>
        public Task UpdateEventDetails(int id, UpdateEventCategoryDTO updateEventCategoryDTO);
        public Task<List<AdminBaseEventCategoryDTO>> GetAllEventCategories();


    }
}
