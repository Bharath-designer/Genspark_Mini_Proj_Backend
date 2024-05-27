using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Service
{
    public interface IEventCategoryService
    {
        public Task CreateEventCategory(CreateEventCategoryDTO eventCategoryDTO);
        public Task<List<EventCategoryDTO>> GetAllEventCategories();

    }
}
