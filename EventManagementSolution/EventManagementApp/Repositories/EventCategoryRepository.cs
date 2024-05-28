using EventManagementApp.Context;
using EventManagementApp.DTOs.EventCategory;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EventManagementApp.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory, int>, IEventCategoryRepository
    {
        public EventCategoryRepository(EventManagementDBContext _context) : base(_context)
        {
        }

        public async Task<List<BaseEventCategoryDTO>> GetAllActiveEventCategories()
        {
            List<BaseEventCategoryDTO> eventCategories = await _context.EventCategories
                .Where(e=>e.IsActive)
                .Select(ec => new BaseEventCategoryDTO
                {
                    EventCategoryId = ec.EventCategoryId,
                    EventName = ec.EventName,
                    Description = ec.Description,
                    CreatedDate = ec.CreatedDate
                })
                .ToListAsync();

            return eventCategories;
        }

    }
}
