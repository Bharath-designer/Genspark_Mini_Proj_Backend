using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.Models;

namespace EventManagementApp.Interfaces.Repository
{
    public interface IEventCategoryRepository: IRepository<EventCategory, int>
    {
        public Task<List<BaseEventCategoryDTO>> GetAllActiveWithReviews();
        public Task<List<AdminBaseEventCategoryDTO>> GetAllWithReviews();

    }
}
