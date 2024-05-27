using EventManagementApp.Context;
using EventManagementApp.Interfaces.Repository;
using EventManagementApp.Models;

namespace EventManagementApp.Repositories
{
    public class EventCategoryRepository : Repository<EventCategory, int>, IEventCategoryRepository
    {
        public EventCategoryRepository(EventManagementDBContext context) : base(context)
        {
        }
    }
}
