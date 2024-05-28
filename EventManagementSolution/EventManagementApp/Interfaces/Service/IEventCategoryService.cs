using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Service
{
    public interface IEventCategoryService
    {
        public Task<List<BaseEventCategoryDTO>> GetAllEventCategories();

    }
}
